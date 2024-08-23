namespace QuickReserve.Application.Features.Companies.Dtos
{
    public class UpdatedCompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public int IndustryTypeId { get; set; }

    }
}
