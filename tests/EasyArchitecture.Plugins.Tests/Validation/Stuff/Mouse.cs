namespace EasyArchitecture.Plugins.Tests.Validation.Stuff
{
    public class Mouse
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            var o = obj as Mouse;

            if(o == null)
            return false;

            return (
                       o.Id == this.Id
                       &&
                       o.Age == this.Age
                       &&
                       o.Name == this.Name
                   );

        }
    }
}
