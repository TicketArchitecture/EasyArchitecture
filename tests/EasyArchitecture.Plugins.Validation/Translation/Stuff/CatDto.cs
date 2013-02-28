namespace EasyArchitecture.Plugins.Validation.Translation.Stuff
{
    public class CatDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public long Id  { get; set; }

        public override bool Equals(object obj)
        {
            var dto = obj as CatDto;
            if (dto == null)
                return false;

            return dto.Age == this.Age && dto.Name == this.Name && dto.Id == this.Id;
        }
    }
}