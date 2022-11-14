using ScorePrediction.Web.Models.Domain;

namespace ScorePrediction.Web.Models
{
    public class DataSeeder
    {
        private readonly ScorePredictionDbContext _dbContext;
        private readonly IServiceProvider _services;

        public DataSeeder(
            ScorePredictionDbContext dbContext, 
            IServiceProvider services)
        {
            _dbContext = dbContext;
            _services = services;
        }

        public void Seed()
        {
            // Get a logger
            var _logger = _services.GetRequiredService<ILogger<DataSeeder>>();


            ArgumentNullException.ThrowIfNull(_dbContext, nameof(_dbContext));
            _dbContext.Database.EnsureCreated();

            // Look for any Tournaments.
            if (_dbContext.Tournaments.Any())
            {
                _logger.LogInformation("The database was already seeded");
                return;   // DB has been seeded
            }

            // Look for any Tournaments.
            if (!_dbContext.Tournaments.Any())
            {
                _logger.LogInformation("The database was already seeded");
                return;   // DB has been seeded
            }


            _logger.LogInformation("Start seeding the database.");

            var tournaments = new Tournament[]
{
            new Tournament
            {
                Id=new Guid("b771193f-4891-4643-b494-0facf2f90a6b"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Fen Football 1",
                StartOn=DateTime.Parse("2022-01-01"),EndOn=DateTime.Parse("2022-01-01"),ScorePrediction=true,
                Image="crizal/img/world-cup/blog-7.png"
            },

            new Tournament
            {
                Id=new Guid("9edb9840-ffab-4db5-a216-e0635760beda"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Fen Football 1",
                StartOn=DateTime.Parse("2022-01-01"),EndOn=DateTime.Parse("2022-01-01"),ScorePrediction=true,
                Image="crizal/img/world-cup/blog-7.png"
            },

};
            foreach (Tournament s in tournaments)
            {
                _dbContext.Tournaments.Add(s);
            }
            _dbContext.SaveChanges();



            var groups = new Group[]
{
            new Group { Id=new Guid("f95a624c-8228-4fef-a78a-c4ab86ccd4d4"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Group A"},
            new Group { Id=new Guid("81b83681-089a-4942-8a9d-69fc7302ce1b"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Group B"},
            new Group { Id=new Guid("f0f03bcd-e94f-4e0a-ba59-1eb9347e3131"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Group C"},
            new Group { Id=new Guid("48333a87-6906-41b4-941f-b77a445f30cb"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Group D"},
            new Group { Id=new Guid("6a7f4ce6-c746-4b29-9835-5ecd538855a8"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Group E"},
            new Group { Id=new Guid("383338fe-cf81-4615-bba1-13e94a56de47"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Group F"},
            new Group { Id=new Guid("78ac6961-f355-4aea-8ba1-bb441a7db402"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Group G"},
            new Group { Id=new Guid("81e9813c-96a9-469d-a3c2-7c8caab285e3"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Group H"},
};
            //foreach (Group s in groups)
            //{
            //    _dbContext.Groups.Add(s);
            //}
            //_dbContext.SaveChanges();


            var teams = new Team[]
{
            new Team { Id=new Guid("e33e1c84-571f-4986-8205-b5a80a479cfa"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Qatar",Logo="crizal/img/flag/qatar.png"},
            new Team { Id=new Guid("de7fad64-5204-4d26-b2f3-fee2d19a04c0"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Ecuador",Logo="crizal/img/flag/ecuador.png"},
            new Team { Id=new Guid("96765cf0-e05f-48d1-a974-c86558bc3cc9"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Senegal",Logo="crizal/img/flag/senegal.png"},
            new Team { Id=new Guid("76d118c1-3694-4f4b-bc12-fc5eb528ca16"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Netherlands",Logo="crizal/img/flag/netherlands.png"},

            //new Team { Id=new Guid("1918bd7a-c425-44eb-8374-beeb649a05bb"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="England",Logo="crizal/img/flag/England.png"},
            //new Team { Id=new Guid("7e6a2169-2b16-45cf-b7d2-8dce3a6b7d17"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Iran",Logo="crizal/img/flag/Iran.png"},
            //new Team { Id=new Guid("ec73bf11-de38-4613-b92b-ad8195924958"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="USA",Logo="crizal/img/flag/USA.png"},
            //new Team { Id=new Guid("ce91d4ba-3966-4af5-a1ad-855e99cd1eb5"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Wales",Logo="crizal/img/flag/Wales.png"},

            //new Team { Id=new Guid("ef98941d-a43b-4e03-b4ab-882dec2e4737"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Argentina",Logo="crizal/img/flag/Argentina.png"},
            //new Team { Id=new Guid("dfb9e1fc-a1b4-454f-aa6a-15db404b79ea"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Saudi Arabia",Logo="crizal/img/flag/qatar.png"},
            //new Team { Id=new Guid("e4e341fa-267e-4df6-a3b5-5b6226336f81"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Mexico",Logo="crizal/img/flag/Mexico.png"},
            //new Team { Id=new Guid("a116247c-125e-4887-867e-031ce62f919b"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Poland",Logo="crizal/img/flag/Poland.png"},

            //new Team { Id=new Guid("a4ae4685-4976-4647-9c2d-47fad498cb2b"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="France",Logo="crizal/img/flag/France.png"},
            //new Team { Id=new Guid("86cf710c-c0b8-40cb-96e4-93a1db946bb0"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Australia",Logo="crizal/img/flag/Australia.png"},
            //new Team { Id=new Guid("b17f9705-2cd9-4f52-a4e9-c0f8e7ad385c"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Denmark",Logo="crizal/img/flag/Denmark.png"},
            //new Team { Id=new Guid("1dd30ed6-2c34-43c7-8520-95402abde98e"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Tunisia",Logo="crizal/img/flag/Tunisia.png"},



            //new Team { Id=new Guid("89dc545e-e65d-45d7-993c-3a3aa5e6502f"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Spain",Logo="crizal/img/flag/spain.png"},
            //new Team { Id=new Guid("a3022016-5224-44f9-a5b5-16133c0441ab"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Costa Rica",Logo="crizal/img/flag/qatar.png"},
            //new Team { Id=new Guid("a519b985-f00a-4068-be69-6006a1d3a27a"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Germany",Logo="crizal/img/flag/germany.png"},
            //new Team { Id=new Guid("eb4d6dc6-52ae-4f35-882f-b28ca9efc64b"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Japan",Logo="crizal/img/flag/japan.png"},

            //new Team { Id=new Guid("c8fe15d0-8fe2-4618-b642-d0ba12709056"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Belgium",Logo="crizal/img/flag/belgium.png"},
            //new Team { Id=new Guid("7ffb3d22-26c2-41dc-ac57-1bae7d29ea94"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Canada",Logo="crizal/img/flag/canada.png"},
            //new Team { Id=new Guid("f4783d13-76bf-4c4c-800a-8641a19f3b27"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Morocco",Logo="crizal/img/flag/morocco.png"},
            //new Team { Id=new Guid("c9e1d3a2-d9d6-4b62-ba9e-350dff7aaa07"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Croatia",Logo="crizal/img/flag/croatia.png"},

            //new Team { Id=new Guid("86fd5747-0cb4-4f12-8bac-2d8ecc6f6ce7"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Brazil",Logo="crizal/img/flag/brazil.png"},
            //new Team { Id=new Guid("aa4fdb40-e1db-4fdd-9c98-edd0db754952"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Serbia",Logo="crizal/img/flag/serbia.png"},
            //new Team { Id=new Guid("108b98ec-4d7e-4dc0-b3b8-7341947aa40b"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Switzerland",Logo="crizal/img/flag/switzerland.png"},
            //new Team { Id=new Guid("e15ddda2-fbe3-4504-8aa1-e5f9d8ec9aec"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Cameroon",Logo="crizal/img/flag/cameroon.png"},

            //new Team { Id=new Guid("97773992-2e70-47e5-8eda-b1153b74389e"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Portugal",Logo="crizal/img/flag/portugal.png"},
            //new Team { Id=new Guid("97d06f2f-9c37-49d5-94cd-b9bf4a7d9972"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Ghana",Logo="crizal/img/flag/ghana.png"},
            //new Team { Id=new Guid("9a718386-8876-4b3c-bda3-1de4649a48ab"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="Uruguay",Logo="crizal/img/flag/uruguay.png"},
            //new Team { Id=new Guid("65f37a72-4ce2-4516-a173-723a1eacfebc"),CreatedBy="1222",CreatedOn=DateTime.Now,Name="South Korea",Logo="crizal/img/flag/qatar.png"},
};
            foreach (Team s in teams)
            {
                _dbContext.Teams.Add(s);
            }
            _dbContext.SaveChanges();



            var matches = new Match[]
{
            new Match { Id=new Guid("63ecfb7d-88b2-42c4-b145-58a04b3c0e12"),CreatedBy="1222",CreatedOn=DateTime.Now,MatchTitle ="Team 1 vs Team 2",StartOn = DateTime.Parse("2022-11-14"),PublishedOn  = DateTime.Parse("2022-01-01")},
            new Match { Id=new Guid("39b8f84f-cd0e-4978-a1cd-7720f90ca81c"),CreatedBy="1222",CreatedOn=DateTime.Now,MatchTitle ="Team 1 vs Team 2",StartOn = DateTime.Parse("2022-11-14"),PublishedOn  = DateTime.Parse("2022-01-01")},
            new Match { Id=new Guid("8bc1eb63-1389-472e-8c1f-5840055e72a9"),CreatedBy="1222",CreatedOn=DateTime.Now,MatchTitle ="Team 1 vs Team 2",StartOn = DateTime.Parse("2022-11-15"),PublishedOn  = DateTime.Parse("2022-01-01")},
            new Match { Id=new Guid("0e71146a-25dd-40e0-8b63-c477f6203f60"),CreatedBy="1222",CreatedOn=DateTime.Now,MatchTitle ="Team 1 vs Team 2",StartOn = DateTime.Parse("2022-11-15"),PublishedOn  = DateTime.Parse("2022-01-01")},
};
            foreach (Match s in matches)
            {
                _dbContext.Matches.Add(s);
            }
            _dbContext.SaveChanges();


            _logger.LogInformation("Finished seeding the database.");
        }
    }
}
