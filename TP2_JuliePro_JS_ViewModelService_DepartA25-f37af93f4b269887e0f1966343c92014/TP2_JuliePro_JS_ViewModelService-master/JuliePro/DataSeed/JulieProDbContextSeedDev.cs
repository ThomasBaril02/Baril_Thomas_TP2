using Bogus;
using Bogus.DataSets;
using JuliePro.Data;
using JuliePro.Models;
using JuliePro.Utility;

namespace JuliePro.DataSeed
{
    public class JulieProDbContextSeedDev : JulieProDbContextSeed
    {
        public JulieProDbContextSeedDev(ILogger<JulieProDbContextSeed> logger, JulieProDbContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment environement) : base(logger, context, environement.WebRootPath)
        {
            Randomizer.Seed = new Random(2546);
        }

        protected override List<Certification> GetCertifications()
        {
            var certificationCenters = new[] {
            "Neki University"
            ,"Roobek College"
            ,"Idadis University"
            ,"Pamu Training"
            ,"Ourmar Endur College"
            ,"Belenca Naw Research"
            ,"The Foco Narth University"
            ,"Potoganio College"
            ,"Fali Training"};

            var titles = new[] {
            "Entraîneur"
            ,"Physiothérapeute"
            ,"Kinésiologue"
            ,"Nutritioniste"};

            List<Certification> certifications = new List<Certification>();
            foreach (var certificationCetner in certificationCenters)
            {
                foreach (var title in titles)
                {
                    certifications.Add(new Certification()
                    {
                        CertificationCenter = certificationCetner,
                        Title = title
                    });
                }
            }

            return certifications;
        }


        protected override List<Discipline> GetDisciplines()
        {
            var olympicDisciplines = new[] {
                "Aviron",
                "Badminton",
                "Basketball",
                "Biathlon",
                "Bobsleigh",
                "Boxe",
                "Curling",
                "Escrime",
                "Football",
                "Gymnastique Artistique",
                "Haltérophilie",
                "Hockey sur glace",
                "Judo",
                "Luge",
                "Natation",
                "Natation Artistique",
                "Patinage de vitesse",
                "Plongeon",
                "Saut à ski",
                "Skateboard",
                "Ski acrobatique",
                "Ski alpin",
                "Ski de fond",
                "Snowboard",
                "Surf",
                "Tir à L'Arc",
                "Trampoline",
                "Volleyball"
                
            };
            List<Discipline> disciplines = new();
            Lorem lorem = new Lorem();
            foreach(var disciplineName in olympicDisciplines)
            {
                disciplines.Add(new Discipline()
                {
                    Name = disciplineName,
                    Description = $"La discipline du {disciplineName} est une superbe activité. Elle est à essayer. Comme le disait si bien Philippidès : " + lorem.Text()
                }) ;
                
            }

            return disciplines;
        }

        protected override List<Trainer> GetTrainers()
        {
            var imagesList = new[] {
                "2fa2a383-6498-4adb-8b8b-f19b7610519d",
                "365ac584-bacb-4828-8c53-3f176e6d2282",
                "c04ff225-2e8c-46bc-894f-16ed0929abc8",
                "fd9f12d4-b799-4769-8940-049a5acde4b5",
                "63dad243-f06c-4a37-8cbe-7d8c71ff5d6a",
                "42ccfe7a-718e-4c63-a89c-10c09ddd8d15",
                "09e062f1-722f-47ab-a9e3-2f56c8d33264",
                "995e08ba-2cdc-41f0-9b37-e52215073f87",
                "4fc7e590-f080-4cd3-ae23-06e73fff13de",
                "3f31f3d1-39b6-4989-b8ee-6c1228a18e4c",
                "86b2ceee-6010-411a-8894-c6cab3a9b933",
                "afbbad4b-561b-44e4-9aaa-21155b9535c9",
                "fc66e3b9-9f62-4322-ad7a-bcdd1d4c3a12",
                "f116cd4a-305e-4895-bbb7-25369046a986",
                "32679248-df1c-4ffd-9b9a-8f865894a3e2",
                "614eaac7-1bda-407e-af9f-8f5e29c2b5df",
                "80fe3aea-1a6c-45a5-87e7-b32888af478e",
                "18d49a52-f316-4c1a-bb81-fede762c1983",
                "5cc13531-35a6-49d4-a154-434d563d4aae",
                "a0413262-e6dd-40cc-a780-ca0d95ba39bf",
                "116dc393-c7af-4e02-859d-9dce24be8940",
                "8da71090-1c03-4a6b-a42e-7131af85ae35",
                "52e21d78-aab3-4c6a-9f1f-1ec69663a785",
                "d29a02ee-c7e8-4cd6-b5dc-22afa995b4d2",
                "4008e73b-4147-4f68-bdea-eb2a99645db0",
                "f7daac94-a747-4907-91ea-701909454560",
                "71c6c4d3-388d-4759-8004-535faf033d37",
                "3280d905-d167-48e8-8dc3-6f825b22acab",
                "188d9c56-7470-45a3-ac5a-818ddea7e958",
                "1798c228-0afa-40dd-8687-5ce68c2a6422",
                "71e80d53-8460-4d26-89a7-96556054cc89",
                "a66dc7c2-5c01-41d6-b0a5-8d3f89e5bb56",
                "c99611ff-0768-42e6-a353-5575634385df",
                "2066ab1c-6353-4c7c-8f68-277fe546156f",
                "407dda46-3651-4b2a-8e5a-6c0f18ffb77f",
                "7d910963-c7f3-4cdf-9032-34b132b1432f",
                "f06127a8-4d92-45fa-8649-5be27b3e38dd",
                "7eb3e9be-f7a0-4ce2-bb76-37bc03342780",
                "f74f7d20-7146-445e-b1f3-1753cbe2a95d",
                "2f878853-9909-4864-92ae-306b0141fec2",
                "dbd52b32-06b0-4ee5-a8eb-3c19b1da146d",
                "edb7231d-858c-4e71-a4e7-1e2f1775e27f",
                "74d1f091-e934-4723-9a47-7215026ed701",
                "949bbc88-4075-4b83-bfc5-0972a4955006",
                "a7bb52b3-2ac6-41df-a15c-2d8113c42751",
                "8a8f6b82-0c17-4874-bbb7-a2ffc58c41f0",
                "900c3805-d48b-4f9c-9ce5-50d489f96695",
                "f8ef6e18-0809-4078-94df-3fa5bf2d5689",
                "29f82e72-9854-4cf6-b80e-5b7c85ddbefc",
                "09f54742-3726-469f-b2b2-3767bff0ccc9",
                "f500c188-32e8-4840-8d65-fb7fc9f618ff",
                "bce35388-a3eb-42f8-adf4-fe3046939ab3",
                "e55a2953-a002-48f1-b0a8-c327d68ea50c",
                "bdf3c4d8-6940-42d2-8a8f-401d08e2510b",
                "a28f1d6d-907c-442a-b209-0c816852cd28",
                "4736c147-43fd-482f-9aaa-5d765fe674ce",
                "0bcaa5c7-d2c9-4905-b551-cbd424ca90e3",
                "e563ca7c-22c9-454a-9282-0c788c2a77e9",
                "ed5930e4-3574-459f-879b-3405e73b0075",
                "6cde9c7e-ec5e-4841-b775-6ec694e344b1",
                "3646ea36-a43b-46cd-89f7-8ee5f915d45b",
                "c9c7987e-2317-4868-a051-2aa8ff135eba",
                "5c58aa2e-8ae7-4acb-a739-679901e0d5e5",
                "f7782c64-c755-4ace-8c71-cc19d4183832",
                "85aeeb3c-d083-4dbc-bebb-fc8b11971f73",
                "56373018-91d2-4dea-af8f-13ba0d85b499",
                "0703d1e4-1c22-418c-8f80-800f6fdb7f31",
                "5f59c8c1-0461-4ccb-be86-9247d18cd285",
                "2dd29f6f-e705-47fc-959f-d9b4eeac02d2",
                "a894021f-1bb7-4885-af3d-68a221e135ac",
                "9de2b838-db52-4130-9e01-13cfdcab7e4b",
                "70da9ffa-f903-49c5-9209-25e431c65a60",
                "7434e915-e4d9-4e7e-9dc0-1e6254eaf8d9",
                "aa67a894-2a76-4f20-a4e3-919b814478e0",
                "cc22faaa-9530-45f0-846e-db608f4c6dd7",
                "4109bd87-e368-418f-b795-d634ac84ae10",
                "4f332008-3539-4c43-ba16-879d2727eff2",
                "3ad16b54-e7c2-479a-8a53-8fe1ea19d936",
                "02b97faf-33e7-405f-8ef1-6d913e50db87",
                "792afcb3-4104-4ed3-afc5-ff35ad4cb935",
                "e654051d-475e-4a3b-9554-00273ec6b84e",
                "c42c4ad0-0826-46b4-a444-0b3136949e94",
                "91d7176f-269b-476e-96e4-2f0a59793f73",
                "8cfb92a6-2d0d-4a89-a636-e29b2e12a874",
                "cf76d439-cea3-48ad-90a3-5e81c9ebbdae",
                "1de11515-017a-4653-b212-4e4a68430d14",
                "836bebab-9e4a-4c90-b33e-c9bd94df58c2",
                "9ce1af57-a5f4-46fc-96e7-804e36f20d79",
                "941a35eb-1b36-40aa-933b-01f43d4895e7",
                "b2c636aa-93cd-4477-8746-2421100fffe9",
                "45a6e2cf-2be9-412a-959b-8cc521823be8",
                "7ff86f52-ac89-4e03-9095-e0e7512aaeb2",
                "ce504472-c106-4e82-b456-ad66fe14a3f0",
                "9e0d5091-1fc3-44be-afec-7ba84160323e",
                "5fe4a0a8-92cc-4694-95c3-773b04b3d737",
                "497ec6ac-ef7e-4272-97a3-15a3c1baa348",
                "04f25ce1-e742-414e-9ea0-4edf92b5a8bc",
                "3625fbfd-9f9a-433e-b75b-9ea7848f663d",
                "8ab7fec5-d77d-4fbc-aab4-414cef4f8e87",
                "a3b893cf-0888-4e03-8a89-34e706f77387",
                "167a31bf-e256-49af-9749-1aff3ab0e528",
                "d16d6571-7d0e-475f-ae19-8ad8e3177da6",
                "346bb1a9-3595-41d7-8ad8-188170a9547e",
                "2a49e72a-c1dc-4d10-aa77-c80056be936b",
                "c632bc1b-b1d3-48a2-81cd-e1cdf3fc1c9f",
                "dfadc780-7bae-49a0-9fbb-9115a96b1496",
                "f052feca-d126-4501-b477-01fba747104a",
                "a6e685cf-c552-4430-8a2e-afdde244f19f",
                "4b3bd771-3a62-4674-ab75-745e7584215e",
                "dca905be-a849-4894-83be-3e13ff2eb7a6",
                "eec016ca-42a3-4a7a-a8a3-e729eb79c251",
                "09461df6-cd31-4bf2-92a2-8f9df2193525",
                "1c6a41c3-b871-443b-884f-62aaaf3d905e",
                "3f0dfc2e-0e94-4c7d-9787-1aab82e58463",
                "4f46a22b-2b1c-4e60-8090-5b2f83ca6803",
                "f633963c-4a83-4464-a1fd-26047146191d",
                "78384c5f-beb6-4c85-acf6-09023c97da70",
                "8b15e5ea-ff6e-4868-a18f-87fd67477e70",
                "c8b2f278-3c00-4c34-8a88-8a36e3d04348",
                "11785e89-46be-4ff2-8c16-e551eba826ff",
                "e62c071a-5cc9-46b9-acd0-1201d1c49100",
                "897a873f-e39e-4e85-9dd5-b736bdf88cdb",
                "f4667307-313a-442c-8925-1236ebbfc15d",
                "d0ca1d2f-8cac-485f-949c-ac4adb97bc83",
                "db95e976-c989-40bb-a025-c92ac4b35bbe",
                "a743e274-a643-44b8-86b5-edafe684411a",
                "2c538db5-001f-4991-97f4-857287657ea8",
                "64c978bc-e432-42c6-a67d-6ccc237a9361",
                "9a4a5959-9a37-4886-a005-0ea399639beb",
                "ccd8161d-16f4-4668-9ccf-f5ab76c4302e",
                "b1c99353-005c-4bb6-bf17-4fb4bd4bc2bd",
                "49b01ef0-af35-492a-8c9d-b07fe7389b17",
                "131d7f2b-c96d-448e-b2c2-9c0ad162e9dc",
                "c903a04b-2ad8-41d6-9ccd-e701ee9a46f8",
                "7c6f73e2-f295-4a1b-ba8f-6edac7526090",
                "9e22c481-9383-4b46-ad62-5830b0d0855a",
                "50d4e31f-9dac-4acd-aefb-7c3d3a3b02c2",
                "8c3e5e44-be9c-49e2-b24e-f14d8811d680",
                "7d2b4451-0628-42be-86b1-9475e0c7af07",
                "8c6e95eb-2174-4a3a-99af-bb1587e6b274",
                "762260fe-e998-4f1b-b91d-09589883bdff",
                "752fb1e4-06c3-4e29-85af-63f085812ab4",
                "f27972de-83d9-4598-b535-afae89e01054",
                "49dddf58-c375-4f54-9ff2-90db461879a9",
                "3d89e3ca-348e-4c63-a898-b5370409ba16",
                "69b67dba-e517-45c3-b379-3b15cbb41375",
                "c0a55b77-6367-4524-b3b5-cd3fca7ceb41",
                "6f2514a6-e01b-49f7-b69b-436f696bb5a4",
                "973043d4-e953-4f50-bbf2-1042e012b5ff",
                "515c2182-fce9-4355-ab86-70444855e9e4",
                "3796207b-5007-4ca1-998f-c23102ce7a57",
                "5f2a5440-de40-4363-9892-0b9ff3a5fabe",
                "92e93937-3527-4174-a242-bc8c483ec9bb",
                "8fa34535-d739-4e12-abd1-f5b2582e1fd2",
                "c1a1e342-0700-4f74-bdb8-5307c1f03b4d",
                "d4e72773-5d5b-48ac-adae-9176c226ee26",
                "33a1da88-e6dc-4f54-9406-436461c79ba1",
                "7fe0e201-8cf4-4cc6-969e-8e558e05158e",
                "a1069af2-e420-4c10-99c0-61a3a4906ec4",
                "4b6b1051-fc91-4971-a64a-01b801ba5ac3",
                "a9367e27-fadc-4b20-ac45-003c28fbd714",
                "61d93194-36f4-4424-b0f6-8cdd08e0ab92",
                "65600723-c7f4-456a-8281-9ab8671dbf03",
                "566cca91-53a6-4a75-8537-3bfe1cff8bc4",
                "b16de8db-4ab5-4b25-a338-392d9cb05f72",
                "abfa6073-a75b-4a4b-be0a-67ff9ba52de5",
                "c07e9a67-2d5b-492a-b1ec-67bbc0eaf108",
                "52528cd8-61e0-4761-ad28-77398a5586c1",
                "bc1ca535-f680-42ea-b5f5-eefd6c413428",
                "a7f8fb3e-9484-4dea-8260-aa30569a8920",
                "025df3c6-c719-41b7-9b6d-347c4f1c5791",
                "d188de6a-6fee-411a-b651-ca5eab69b178",
                "c0d70516-b8e4-421e-938c-e2e7e2868abb",
                "774117f7-ca33-42ec-a6b5-691ab3d8eba7",
                "6e09b815-5de1-4574-98cf-a0b89342a153",
                "934c052a-6c6d-4b58-b8f3-2fcc254bd909",
                "b744ecbc-e9a9-46cf-8373-a340ef5f2c8a",
                "8a2f6c1c-afad-4207-bf06-dfd5530ff2a6",
                "7ff03fa7-d13d-49d3-b55c-a0debb39cd78",
                "89db94ff-4dea-4ff8-9387-ce2c1b11a6e9",
                "47b1b3d8-e85b-46ff-9aaa-bebe7dbcba4f",
                "d4277aac-f548-4a79-98ae-28373455c945",
                "78c6d58c-f300-44a2-9777-52e60a8340cf",
                "c2eaf609-ec76-4b9e-b78b-cae13e7d5267",
                "3dc9c24a-ce71-41e9-bd85-4f0cfce6385e",
                "2b0aa016-1278-477d-87cf-d6df6c19bbb0",
                "e0578edd-c268-4831-a2c4-b7c86558b58f",
                "836d15da-853e-4878-8f0a-9f7d92d880ea",
                "6f0c5841-3a63-4a96-b0ad-582897b475ea",
                "aba01a27-9a41-4e0e-8ac7-ce55b7dfba5e",
                "c38b9c36-803e-41a8-b3a6-9c541d9ba7c4",
                "950bc539-baac-4d9c-9f9d-557c5f5387b9",
                "05241192-560c-462c-bc5a-47f59843dee9",
                "7e16f685-c88e-447d-99bb-edf3d0f25c07",
                "08e7e496-fe45-4dd1-8bd1-f9323831a92e",
                "5e47cfd2-6469-438a-a5df-007b69702e5d",
                "b091cc2c-738e-4a3a-b25b-0c7dc2024d98",
                "69a84ddb-f9ad-4057-8556-722894ccc87d",
                "a7b904f8-d65b-472f-9f6e-2d9a9fefbe84",
                "e24c039b-44e5-47a6-97fc-f92adcd7b2f5"
            };
            var disciplines = this.context.Disciplines.Select(x=>x.Id).ToList();

            var trainer = new Faker<Trainer>("fr")
                                    .RuleFor(x => x.FirstName, y => y.Person.FirstName)
                                    .RuleFor(x => x.LastName, y => y.Person.LastName)
                                    .RuleFor(x => x.Email, y => y.Person.Email)
                                    .RuleFor(x => x.Biography, y => y.Lorem.Text())
                                    .RuleFor(x => x.Genre, y => (Genre)((int)y.Person.Gender))
                                    .RuleFor(x => x.Biography, y => y.Lorem.Text())
                                    .RuleFor(x=>x.Discipline_Id, y=> y.Random.CollectionItem(disciplines))
                                    .RuleFor(x => x.Photo, (y, d) => {
                                        var fileName = Guid.Parse(y.Random.Guid().ToString()) + ".jpg";

                                        var faceDirectory = "face-dataset/" + d.Genre.ToString().ToLower() + "/";
                                            File.Copy(y.Random.CollectionItem(Directory.GetFiles(faceDirectory)), wwwrootImagePath + AppConstants.ImagePath + fileName, true);

                                        return fileName;

                                    });
            return trainer.Generate(200);
        }


        protected override List<TrainerCertification> GetTrainerCertifications()
        {
            var certifications = context.Certifications.Select(x => x.Id).ToList();
            var trainers = context.Trainers.Select(x => x.Id).ToList();
            var trainerCertifications = new Faker<TrainerCertification>("fr").
                RuleFor(x => x.DateCertification, y => y.Date.Past(10, new DateTime(2022, 07, 01)))
                .RuleFor(x => x.Certification_Id, y => y.Random.CollectionItem(certifications))
                .RuleFor(x => x.Trainer_Id, y => y.Random.CollectionItem(trainers));

            return trainerCertifications.Generate(100);
        }

        protected override List<Record> GetRecords()
        {
            var disciplines = context.Disciplines.Select(x => x.Id).ToList();
            var trainers = context.Trainers.Select(x => x.Id).ToList();
            var units = new string[] { "m", "km", "kg", "sec", "min"};
            var records = new Faker<Record>("fr")
                .RuleFor(x => x.Amount, y => y.Random.Decimal() * y.Random.UInt(10,100))
                .RuleFor(x=>x.Date, y => y.Date.Past(10, new DateTime(2022, 07, 01)))
                .RuleFor(x=>x.Discipline_Id, y=>y.Random.CollectionItem(disciplines))
                .RuleFor(x=>x.Trainer_Id, y=>y.Random.CollectionItem(trainers))
                .RuleFor(x=>x.Unit, y=>y.Random.CollectionItem(units));

            return records.Generate(500);
        }
    }
}
