namespace EasyArchitecture.Plugins.Validation.Persistence.Stuff
{
    public class Dog
    {
        public virtual string Name { get; set; }
        public virtual int Age { get; set; }
        public virtual int Id { get; set; }
        public virtual bool IsSleeping { get; set; }

        public override bool Equals(object obj)
        {
            var dog = obj as Dog;

            if(dog == null)
            return false;

            return (
                       dog.Id == this.Id
                       &&
                       dog.Age == this.Age
                       &&
                       dog.Name == this.Name
                   );

        }
    }
}
