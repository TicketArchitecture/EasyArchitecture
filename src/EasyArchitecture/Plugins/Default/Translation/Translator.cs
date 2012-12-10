using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EasyArchitecture.Plugins.Default.Translation
{
    public static class Translator
    {
        internal static List<TypeMap> mappedTypes = new List<TypeMap>();
        internal static List<RuleMap> mappedRules = new List<RuleMap>();


        internal static object Translate(object source, object target)
        {
            if (source == null)
                return null;


            ////tratamento map externo
            //TypeMap typeMap = mappedTypes.Find(m => m.Source == source.GetType() && m.Target == target.GetType());
            //if (typeMap != null)
            //{
            //    Func<T, D> func = (Func<T, D>)typeMap.DeclaredMap;
            //    return func(obj);
            //}

            //tratamento map rule
            //D ret = new D();
            object ret = InstanceCreator(target.GetType());
            foreach (var property in source.GetType().GetProperties())
            {
                var value = property.GetValue(source, null);

                if (value == null) continue;

                var targetProperty = target.GetType().GetProperty(property.Name);

                if (targetProperty != null)
                {

                    RuleMap specifRuleMap =
                        mappedRules.Find(
                            m =>
                            m.Source == source.GetType() && m.Target == target.GetType() &&
                            m.PropertySource == property.PropertyType &&
                            m.PropertyTarget == targetProperty.PropertyType);
                    if (specifRuleMap != null)
                    {
                        //get value over mapped property
                        Type generic = typeof(Func<,>);
                        Type specificType =
                            generic.MakeGenericType(new[] { property.PropertyType, targetProperty.PropertyType });

                        value = specificType.InvokeMember("Invoke", BindingFlags.InvokeMethod, null,
                                                          specifRuleMap.DeclaredRuleMap, new object[] { value });
                    }
                    else
                    {
                        //get default value
                        value = ConvertValue(property.PropertyType, targetProperty.PropertyType, value);
                    }

                    targetProperty.SetValue(ret, value, null);
                }
            }
            return ret;
        }

        public static D Translate<T, D>(T obj)
        {
            if (obj == null)
                return default(D);


            //tratamento map externo
            TypeMap typeMap = mappedTypes.Find(m => m.Source == typeof(T) && m.Target == typeof(D));
            if (typeMap != null)
            {
                Func<T, D> func = (Func<T, D>)typeMap.DeclaredMap;
                return func(obj);
            }

            // tratamento map rule
            //D ret = new D();
            D ret = default(D);
            return (D)Translate(obj, ret);

            ////tratamento map rule
            //D ret = new D();
            //foreach (var property in typeof(T).GetProperties())
            //{
            //    var value = property.GetValue(obj, null);

            //    if (value == null) continue;

            //    var targetProperty = typeof (D).GetProperty(property.Name);

            //    if (targetProperty != null)
            //    {

            //        RuleMap specifRuleMap =
            //            mappedRules.Find(
            //                m =>
            //                m.Source == typeof (T) && m.Target == typeof (D) &&
            //                m.PropertySource == property.PropertyType &&
            //                m.PropertyTarget == targetProperty.PropertyType);
            //        if (specifRuleMap != null)
            //        {
            //            //get value over mapped property
            //            Type generic = typeof (Func<,>);
            //            Type specificType =
            //                generic.MakeGenericType(new[] {property.PropertyType, targetProperty.PropertyType});

            //            value = specificType.InvokeMember("Invoke", BindingFlags.InvokeMethod, null,
            //                                              specifRuleMap.DeclaredRuleMap, new object[] {value});
            //        }
            //        else
            //        {
            //            //get default value
            //            value = ConvertValue(property.PropertyType, targetProperty.PropertyType, value);
            //        }

            //        targetProperty.SetValue(ret, value, null);
            //    }
            //}
            //return ret;
        }

        private static object ConvertValue(Type source, Type target, object value)
        {

            //TODO: teste
            //verificar se é lista genérica, se for, manda traduzir os itens da lista
            if (ThisIsGenericList(value) != null)
            {
                value = TranslateGenericList(value, target);
                return value;
            }

            if (source == target || source.IsAssignableFrom(target))
            {
                return value;
            }

            if (source == typeof(string) && string.IsNullOrEmpty((string)value))
            {
                value = Helper.GetDefaultValue(target);
            }

            if (target.IsGenericType)
            {
                target = target.GetGenericArguments()[0];
            }

            //TODO: verificar
            //falta a condicao de obj->obj
            if (target.Name.Contains("DTO") || target.Name.Contains("TO") || source.Name.Contains("DTO") || source.Name.Contains("TO"))
            {
                value = Translate(value, InstanceCreator(target));
            }

            value = Convert.ChangeType(value, target);

            return value;
        }

        public static IList<D> Translate<T, D>(IList<T> list)
            where D : class, new()
            where T : class
        {
            var ret = new List<D>();
            foreach (T obj in list)
            {
                ret.Add(Translate<T, D>(obj));
            }
            return ret;
        }


        public static MapRule<T, D> MapRules<T, D>()
        {
            return new MapRule<T, D>();
        }

        public static void MapType<T, D>(Func<T, D> func)
        {
            mappedTypes.Add(new TypeMap() { Source = typeof(T), Target = typeof(D), DeclaredMap = func });
        }

        internal static Type ThisIsGenericList(Type type)
        {
            Type typeGeneric = null;

            //TODO: working just with Ilist<>
            Type genericListInteface = type.GetInterfaces().FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(ICollection<>));
            if (genericListInteface != null)
            {
                //'e ilist<T>
                var genericTypeDefinition = type.GetGenericTypeDefinition();
                //perguntei do list<> temporariamente
                if ((genericTypeDefinition == typeof(IList<>)) || (genericTypeDefinition == typeof(List<>)))
                {
                    typeGeneric = type.GetGenericArguments().FirstOrDefault();
                }
            }

            return typeGeneric;
        }

        internal static Type ThisIsGenericList(object obj)
        {
            return ThisIsGenericList(obj.GetType());
        }

        private static IList TranslateGenericList(object source, Type target)
        {
            IList targetList = null;

            //verifica se eh ilist<>
            Type sourceGenericType = ThisIsGenericList(source);
            Type targetGenericType = ThisIsGenericList(target);
            if (sourceGenericType != null)
            {
                var sourceList = (IEnumerable)source;
                //targetList = (IList)target;
                targetList = (IList)CreateGeneric(typeof(List<>), targetGenericType);

                foreach (var item in sourceList)
                {
                    var x = Translate(item, InstanceCreator(targetGenericType));
                    //var y = Convert.ChangeType(x, target);
                    //var y = (object) x;
                    targetList.Add(x);
                }
            }
            return targetList;
        }

        private static object InstanceCreator(Type type)
        {
            object destination;

            ////se for entity/vo, usar o construtor especifico
            //if (type.IsSubclassOf(typeof(Entity)) || type.IsSubclassOf(typeof(ValueObject)))
            //{
            //    //temp
            //    destination = type.Assembly.CreateInstance(type.FullName);
            //}
            //else
            //{
            //construtor default
            destination = type.Assembly.CreateInstance(type.FullName);
            //}
            return destination;
        }


        private static T InstanceCreator<T>()
        {
            T destination = default(T);

            ////se for entity/vo, usar o construtor especifico
            //if (typeof(T).IsSubclassOf(typeof(Entity)) || typeof(T).IsSubclassOf(typeof(ValueObject)))
            //{
            //    //temp
            //    destination = (T)typeof(T).Assembly.CreateInstance(typeof(T).FullName);
            //}
            //else
            //{
            //construtor default
            destination = (T)typeof(T).Assembly.CreateInstance(typeof(T).FullName);
            //}
            return destination;
        }

        private static object CreateGeneric(Type generic, Type innerType, params object[] args)
        {
            System.Type specificType = generic.MakeGenericType(new System.Type[] { innerType });
            return Activator.CreateInstance(specificType, args);
        }


        public static T1 Translate<T, T1>(T list, T1 p1)
        {
            throw new NotImplementedException();
        }
    }
}