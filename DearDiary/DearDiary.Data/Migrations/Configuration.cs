using DearDiary.Models;
using System.Data.Entity.Migrations;

namespace DearDiary.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<DearDiary.Data.DearDiaryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DearDiary.Data.DearDiaryDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

                //context.Database.ExecuteSqlCommand(
                //    "INSERT INTO Countries        " +
                //"                           " +
                //"(Name)                     " +
                //"                           " +
                //"VALUES                     " +
                
                //"('Afghanistan'),                               " +
                //"('Albania'),                                   " +
                //"('Algeria'),                                   " +
                //"('Andorra'),                                   " +
                //"('Angola'),                                    " +
                //"('Antigua and Barbuda'),                       " +
                //"('Argentina'),                                 " +
                //"('Armenia'),                                   " +
                //"('Australia'),                                 " +
                //"('Austria'),                                   " +
                //"('Azerbaijan'),                                " +
                //"('Bahamas, The'),                              " +
                //"('Bahrain'),                                   " +
                //"('Bangladesh'),                                " +
                //"('Barbados'),                                  " +
                //"('Belarus'),                                   " +
                //"('Belgium'),                                   " +
                //"('Belize'),                                    " +
                //"('Benin'),                                     " +
                //"('Bhutan'),                                    " +
                //"('Bolivia'),                                   " +
                //"('Bosnia and Herzegovina'),                    " +
                //"('Botswana'),                                  " +
                //"('Brazil'),                                    " +
                //"('Brunei'),                                    " +
                //"('Bulgaria'),                                  " +
                //"('Burkina Faso'),                              " +
                //"('Burma'),                                     " +
                //"('Burundi'),                                   " +
                //"('Cambodia'),                                  " +
                //"('Cameroon'),                                  " +
                //"('Canada'),                                    " +
                //"('Cape Verde'),                                " +
                //"('Central Africa'),                            " +
                //"('Chad'),                                      " +
                //"('Chile'),                                     " +
                //"('China'),                                     " +
                //"('Colombia'),                                  " +
                //"('Comoros'),                                   " +
                //"('Congo'),         " +
                //"('Costa Rica'),                                " +
                //"('Cote dIvoire'),                              " +
                //"('Crete'),                                     " +
                //"('Croatia'),                                   " +
                //"('Cuba'),                                      " +
                //"('Cyprus'),                                    " +
                //"('Czech Republic'),                            " +
                //"('Denmark'),                                   " +
                //"('Djibouti'),                                  " +
                //"('Dominican Republic'),                        " +
                //"('East Timor'),                                " +
                //"('Ecuador'),                                   " +
                //"('Egypt'),                                     " +
                //"('El Salvador'),                               " +
                //"('Equatorial Guinea'),                         " +
                //"('Eritrea'),                                   " +
                //"('Estonia'),                                   " +
                //"('Ethiopia'),                                  " +
                //"('Fiji'),                                      " +
                //"('Finland'),                                   " +
                //"('France'),                                    " +
                //"('Gabon'),                                     " +
                //"('Gambia, The'),                               " +
                //"('Georgia'),                                   " +
                //"('Germany'),                                   " +
                //"('Ghana'),                                     " +
                //"('Greece'),                                    " +
                //"('Grenada'),                                   " +
                //"('Guadeloupe'),                                " +
                //"('Guatemala'),                                 " +
                //"('Guinea'),                                    " +
                //"('Guinea-Bissau'),                             " +
                //"('Guyana'),                                    " +
                //"('Haiti'),                                     " +
                //"('Holy See'),                                  " +
                //"('Honduras'),                                  " +
                //"('Hong Kong'),                                 " +
                //"('Hungary'),                                   " +
                //"('Iceland'),                                   " +
                //"('India'),                                     " +
                //"('Indonesia'),                                 " +
                //"('Iran'),                                      " +
                //"('Iraq'),                                      " +
                //"('Ireland'),                                   " +
                //"('Israel'),                                    " +
                //"('Italy'),                                     " +
                //"('Ivory Coast'),                               " +
                //"('Jamaica'),                                   " +
                //"('Japan'),                                     " +
                //"('Jordan'),                                    " +
                //"('Kazakhstan'),                                " +
                //"('Kenya'),                                     " +
                //"('Kiribati'),                                  " +
                //"('Korea, North'),                              " +
                //"('Korea, South'),                              " +
                //"('Kosovo'),                                    " +
                //"('Kuwait'),                                    " +
                //"('Kyrgyzstan'),                                " +
                //"('Laos'),                                      " +
                //"('Latvia'),                                    " +
                //"('Lebanon'),                                   " +
                //"('Lesotho'),                                   " +
                //"('Liberia'),                                   " +
                //"('Libya'),                                     " +
                //"('Liechtenstein'),                             " +
                //"('Lithuania'),                                 " +
                //"('Macau'),                                     " +
                //"('Macedonia'),                                 " +
                //"('Madagascar'),                                " +
                //"('Malawi'),                                    " +
                //"('Malaysia'),                                  " +
                //"('Maldives'),                                  " +
                //"('Mali'),                                      " +
                //"('Malta'),                                     " +
                //"('Marshall Islands'),                          " +
                //"('Mauritania'),                                " +
                //"('Mauritius'),                                 " +
                //"('Mexico'),                                    " +
                //"('Micronesia'),                                " +
                //"('Moldova'),                                   " +
                //"('Monaco'),                                    " +
                //"('Mongolia'),                                  " +
                //"('Montenegro'),                                " +
                //"('Morocco'),                                   " +
                //"('Mozambique'),                                " +
                //"('Namibia'),                                   " +
                //"('Nauru'),                                     " +
                //"('Nepal'),                                     " +
                //"('Netherlands'),                               " +
                //"('New Zealand'),                               " +
                //"('Nicaragua'),                                 " +
                //"('Niger'),                                     " +
                //"('Nigeria'),                                   " +
                //"('North Korea'),                               " +
                //"('Norway'),                                    " +
                //"('Oman'),                                      " +
                //"('Pakistan'),                                  " +
                //"('Palau'),                                     " +
                //"('Panama'),                                    " +
                //"('Papua New Guinea'),                          " +
                //"('Paraguay'),                                  " +
                //"('Peru'),                                      " +
                //"('Philippines'),                               " +
                //"('Poland'),                                    " +
                //"('Portugal'),                                  " +
                //"('Qatar'),                                     " +
                //"('Romania'),                                   " +
                //"('Russia'),                                    " +
                //"('Rwanda'),                                    " +
                //"('Saint Lucia'),                               " +                
                //"('Samoa'),                                     " +
                //"('San Marino'),                                " +
                //"('Sao Tome and Principe'),                     " +
                //"('Saudi Arabia'),                              " +
                //"('Scotland'),                                  " +
                //"('Senegal'),                                   " +
                //"('Serbia'),                                    " +
                //"('Seychelles'),                                " +
                //"('Sierra Leone'),                              " +
                //"('Singapore'),                                 " +
                //"('Slovakia'),                                  " +
                //"('Slovenia'),                                  " +
                //"('Solomon Islands'),                           " +
                //"('Somalia'),                                   " +
                //"('South Africa'),                              " +
                //"('South Korea'),                               " +
                //"('Spain'),                                     " +
                //"('Sri Lanka'),                                 " +
                //"('Sudan'),                                     " +
                //"('Suriname'),                                  " +
                //"('Swaziland'),                                 " +
                //"('Sweden'),                                    " +
                //"('Switzerland'),                               " +
                //"('Syria'),                                     " +
                //"('Taiwan'),                                    " +
                //"('Tajikistan'),                                " +
                //"('Tanzania'),                                  " +
                //"('Thailand'),                                  " +
                //"('Tibet'),                                     " +
                //"('Timor-Leste'),                               " +
                //"('Togo'),                                      " +
                //"('Tonga'),                                     " +
                //"('Trinidad and Tobago'),                       " +
                //"('Tunisia'),                                   " +
                //"('Turkey'),                                    " +
                //"('Turkmenistan'),                              " +
                //"('Tuvalu'),                                    " +
                //"('Uganda'),                                    " +
                //"('Ukraine'),                                   " +
                //"('United Arab Emirates'),                      " +
                //"('United Kingdom'),                            " +
                //"('United States'),                             " +
                //"('Uruguay'),                                   " +
                //"('Uzbekistan'),                                " +
                //"('Vanuatu'),                                   " +
                //"('Venezuela'),                                 " +
                //"('Vietnam'),                                   " +
                //"('Yemen'),                                     " +
                //"('Zambia'),                                    " +
                //"('Zimbabwe');                                  ");
            
        }
    }
}


