using System;
using System.CodeDom;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;

namespace EasyArchitecture.Core.Serializer
{
    internal class UnknowTypeDataContractSurrogate : IDataContractSurrogate
    {
        public Type GetDataContractType(Type type)
        {
            return type;
        }

        public object GetObjectToSerialize(object obj, Type targetType)
        {
            if((obj.GetType() != targetType) && !targetType.IsInterface )
            {
                obj = obj.GetType().Name;
            }

            return obj;
        }

        public object GetDeserializedObject(object obj, Type targetType)
        {
            return obj;
        }

        public object GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType)
        {
            return null;
        }

        public object GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            return null;
        }

        public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
        {
        }

        public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
        {
            return null;
        }

        public CodeTypeDeclaration ProcessImportedType(CodeTypeDeclaration typeDeclaration, CodeCompileUnit compileUnit)
        {
            return typeDeclaration;
        }
    }
}