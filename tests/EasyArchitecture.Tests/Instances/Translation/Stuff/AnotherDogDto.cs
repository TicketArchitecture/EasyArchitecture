namespace EasyArchitecture.Tests.Instances.Translation.Stuff
{
    public class AnotherDogDto
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public string Alias { get; set; }

        public override bool Equals(object obj)
        {
            var dto = obj as AnotherDogDto;
            if (dto == null)
                return false;

            return dto.Alias == this.Alias && dto.Name == this.Name && dto.Id == this.Id;
        }
    }
}