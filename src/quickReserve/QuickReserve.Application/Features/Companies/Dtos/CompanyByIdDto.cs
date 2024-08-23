namespace QuickReserve.Application.Features.Companies.Dtos
{
    public class CompanyByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public int IndustryTypeId { get; set; }

        public string IndustryTypeName { get; set; }
    }
}
