using CargoDispath.DAL.Entities;
using CargoDispath.Entities;
using System.Collections.Generic;
using System.Data.Entity;
namespace CargoDispath.DAL.EF
{
    class CargoContext : DbContext
    {
        public CargoContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }
        static CargoContext()
        {
            Database.SetInitializer<CargoContext>(new ContextInit());
        }
        //static CargoContext()
        //{
        //    Database.SetInitializer<CargoContext>(new ContextInit());
        //}
        public virtual DbSet<Cargo> _Cargos { get; set; }
        public virtual DbSet<Car> _Cars { get; set; }
        public virtual DbSet<Photo> _Photos { get; set; }
        public virtual DbSet<Country> _Countries { get; set; }
        public virtual DbSet<Region> _Regions { get; set; }
        public virtual DbSet<UserCars> _UserCars { get; set; }
        public virtual DbSet<LoadingType> _LoadignTypes { get; set; }
        public virtual DbSet<CarType> _CarTypes { get; set; }
        public virtual DbSet<VehicleType> _VehicleTypes { get; set; }
        // public virtual DbSet<ApplicationUser> _Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasMany(p => p.Photos)
                .WithRequired(p => p.Car);
            //base.OnModelCreating(modelBuilder);
        }
    }
    internal class ContextInit : CreateDatabaseIfNotExists<CargoContext>
    {
        protected override void Seed(CargoContext context)
        {
            Country cntr1 = new Country { Name = "Украина" };
            Country cntr2 = new Country { Name = "Россия" };
            List<VehicleType> vehicleTypes = new List<VehicleType>
            {
                new VehicleType {Name = "Грузовик" },
                new VehicleType {Name = "Полуприцеп" },
                new VehicleType {Name = "Сцепка" }
            };

            List<CarType> carTypes = new List<CarType>
            {
                new CarType {Name = "Тент"},
                new CarType {Name = "Реф."},
                new CarType {Name = "Изотерм"},
                new CarType {Name = "Цельномет"},
                new CarType {Name = "Бус"},
                new CarType {Name = "Бортовая"},
                new CarType {Name = "Контейнеровоз"},
                new CarType {Name = "Трал/Негабарит"},
                new CarType {Name = "Платформа"},
                new CarType {Name = "Манипулятор"},
                new CarType {Name = "Самосвал"},
                new CarType {Name = "Зерновоз"},
                new CarType {Name = "Кран"},
                new CarType {Name = "Автовоз"},
                new CarType {Name = "Цистерна"},
                new CarType {Name = "Лесовоз"},
                new CarType {Name = "Эвакуатор"}
            };
            List<LoadingType> loadingTypes = new List<LoadingType>
            {
                new LoadingType {Name="верхняя"},
                new LoadingType {Name="боковая"},
                new LoadingType {Name="задняя"},
                new LoadingType {Name="с полной растентовкой"},
                new LoadingType {Name="со снятием поперечин"},
                new LoadingType {Name="со снятием стоек"},
                new LoadingType {Name="без ворот"},
            };
            List<Region> regionsUA = new List<Region>{
                new Region {Name = "Винницкая обл",Country = cntr1,},
                new Region {Name = "Волынская обл",Country = cntr1,},
                new Region {Name = "Днепропетровская обл",Country = cntr1,},
                new Region {Name = "Донецкая обл",Country = cntr1},
                new Region {Name = "Житомырская обл",Country = cntr1},
                new Region {Name = "Закарпатская обл",Country = cntr1},
                new Region {Name = "Запорожская обл",Country = cntr1},
                new Region {Name = "Ивано-Франковская обл",Country = cntr1},
                new Region {Name = "Киевская обл",Country = cntr1},
                new Region {Name = "Кировоградская обл",Country = cntr1},
                new Region {Name = "Луганская обл",Country = cntr1},
                new Region {Name = "Львовская обл",Country = cntr1},
                new Region {Name = "Николаевская обл",Country = cntr1},
                new Region {Name = "Одесская обл", Country = cntr1},
                new Region {Name = "Полтавская обл", Country = cntr1},
                new Region {Name = "Ровненская обл",Country = cntr1},
                new Region {Name = "Сумская обл",Country = cntr1},
                new Region {Name = "Тернопольская обл",Country = cntr1},
                new Region {Name = "Харьковская обл",Country = cntr1},
                new Region {Name = "Херсонская обл",Country = cntr1},
                new Region {Name = "Хмельницкая обл",Country = cntr1},
                new Region {Name = "Черкаская обл",Country = cntr1},
                new Region {Name = "Черниговская обл",Country = cntr1},
                new Region {Name = "Черновицая обл", Country = cntr1},
                new Region {Name = "Севастополь обл",Country = cntr1},
                new Region {Name = "АР Крым обл",Country = cntr1},
                new Region {Name = "Донецкая обл",Country = cntr1},
            };

            List<Region> regionsRU = new List<Region>
            {
                new Region {Name="Амурская обл",Country=cntr2},
                new Region {Name="Арахангельская обл",Country=cntr2},
                new Region {Name="Астраханская обл",Country=cntr2},
                new Region {Name="Белгородская обл",Country=cntr2},
                new Region {Name="Брянская обл",Country=cntr2},
                new Region {Name="Иркутская обл",Country=cntr2},
                new Region {Name="Ивановская обл",Country=cntr2},
                new Region {Name="Калининградская обл",Country=cntr2},
                new Region {Name="Калужская обл",Country=cntr2},
                new Region {Name="Кемеровская обл",Country=cntr2},
                new Region {Name="Кировская обл",Country=cntr2},
                new Region {Name="Костромская обл",Country=cntr2},
                new Region {Name="Курганская обл",Country=cntr2},
                new Region {Name="Курская обл",Country=cntr2},
                new Region {Name="Ленинградская обл",Country=cntr2},
                new Region {Name="Липецкая обл",Country=cntr2},
                new Region {Name="Магаданская обл",Country=cntr2},
                new Region {Name="Московская обл",Country=cntr2},
                new Region {Name="Мурманская обл",Country=cntr2},
                new Region {Name="Нижегородская обл",Country=cntr2},
                new Region {Name="Новгородская обл",Country=cntr2},
                new Region {Name="Новосибирская обл",Country=cntr2},
                new Region {Name="Омская обл",Country=cntr2},
                new Region {Name="Оренбургская обл",Country=cntr2},
                new Region {Name="Орловская обл",Country=cntr2},
                new Region {Name="Пензенская обл",Country=cntr2},
                new Region {Name="Псковская обл",Country=cntr2},
                new Region {Name="Ростовская обл",Country=cntr2},
                new Region {Name="Разянская обл",Country=cntr2},
                new Region {Name="Саханская обл",Country=cntr2},
                new Region {Name="Самарская обл",Country=cntr2},
                new Region {Name="Саратовская обл",Country=cntr2},
                new Region {Name="Смоленская обл",Country=cntr2},
                new Region {Name="Свердловская обл",Country=cntr2},
                new Region {Name="Тамбовская обл",Country=cntr2},
                new Region {Name="Томская обл",Country=cntr2},
                new Region {Name="Тверская обл",Country=cntr2},
                new Region {Name="Тюменская обл",Country=cntr2},
                new Region {Name="Ульяновская обл",Country=cntr2},
                new Region {Name="Владимирская обл",Country=cntr2},
                new Region {Name="Волгоградская обл",Country=cntr2},
                new Region {Name="Вологодская обл",Country=cntr2},
                new Region {Name="Воронежская обл",Country=cntr2},
                new Region {Name="Ярославская  обл",Country=cntr2},
            };
            context._Regions.AddRange(regionsUA);
            context._Regions.AddRange(regionsRU);
            context._Countries.Add(cntr1);
            context._Countries.Add(cntr2);
            context._LoadignTypes.AddRange(loadingTypes);
            context._CarTypes.AddRange(carTypes);
            context._VehicleTypes.AddRange(vehicleTypes);
            base.Seed(context);
        }
    }
    //public class ContextInit : CreateDatabaseIfNotExists<CargoContext>
    //{
    //    protected override void Seed(CargoContext context)
    //    {
    //        
    //        List<VehicleType> vehicleTypes = new List<VehicleType>
    //        {
    //            new VehicleType {Name = "Грузовик" },
    //            new VehicleType {Name = "Полуприцеп" },
    //            new VehicleType {Name = "Сцепка" }
    //        };

    //        List<CarType> carTypes = new List<CarType>
    //        {
    //            new CarType {Name = "Тент"},
    //            new CarType {Name = "Реф."},
    //            new CarType {Name = "Изотерм"},
    //            new CarType {Name = "Цельномет"},
    //            new CarType {Name = "Бус"},
    //            new CarType {Name = "Бортовая"},
    //            new CarType {Name = "Контейнеровоз"},
    //            new CarType {Name = "Трал/Негабарит"},
    //            new CarType {Name = "Платформа"},
    //            new CarType {Name = "Манипулятор"},
    //            new CarType {Name = "Самосвал"},
    //            new CarType {Name = "Зерновоз"},
    //            new CarType {Name = "Кран"},
    //            new CarType {Name = "Автовоз"},
    //            new CarType {Name = "Цистерна"},
    //            new CarType {Name = "Лесовоз"},
    //            new CarType {Name = "Эвакуатор"}
    //        };
    //        List<LoadingType> loadingTypes = new List<LoadingType>
    //        {
    //            new LoadingType {Name="верхняя"},
    //            new LoadingType {Name="боковая"},
    //            new LoadingType {Name="задняя"},
    //            new LoadingType {Name="с полной растентовкой"},
    //            new LoadingType {Name="со снятием поперечин"},
    //            new LoadingType {Name="со снятием стоек"},
    //            new LoadingType {Name="без ворот"},
    //        };
    //        List<Region> regionsUA = new List<Region>{
    //            new Region {Name = "Винницкая обл",Country = cntr1,},
    //            new Region {Name = "Волынская обл",Country = cntr1,},
    //            new Region {Name = "Днепропетровская обл",Country = cntr1,},
    //            new Region {Name = "Донецкая обл",Country = cntr1},
    //            new Region {Name = "Житомырская обл",Country = cntr1},
    //            new Region {Name = "Закарпатская обл",Country = cntr1},
    //            new Region {Name = "Запорожская обл",Country = cntr1},
    //            new Region {Name = "Ивано-Франковская обл",Country = cntr1},
    //            new Region {Name = "Киевская обл",Country = cntr1},
    //            new Region {Name = "Кировоградская обл",Country = cntr1},
    //            new Region {Name = "Луганская обл",Country = cntr1},
    //            new Region {Name = "Львовская обл",Country = cntr1},
    //            new Region {Name = "Николаевская обл",Country = cntr1},
    //            new Region {Name = "Одесская обл", Country = cntr1},
    //            new Region {Name = "Полтавская обл", Country = cntr1},
    //            new Region {Name = "Ровненская обл",Country = cntr1},
    //            new Region {Name = "Сумская обл",Country = cntr1},
    //            new Region {Name = "Тернопольская обл",Country = cntr1},
    //            new Region {Name = "Харьковская обл",Country = cntr1},
    //            new Region {Name = "Херсонская обл",Country = cntr1},
    //            new Region {Name = "Хмельницкая обл",Country = cntr1},
    //            new Region {Name = "Черкаская обл",Country = cntr1},
    //            new Region {Name = "Черниговская обл",Country = cntr1},
    //            new Region {Name = "Черновицая обл", Country = cntr1},
    //            new Region {Name = "Севастополь обл",Country = cntr1},
    //            new Region {Name = "АР Крым обл",Country = cntr1},
    //            new Region {Name = "Донецкая обл",Country = cntr1},
    //        };

    //        List<Region> regionsRU = new List<Region>
    //        {
    //            new Region {Name="Амурская обл",Country=cntr2},
    //            new Region {Name="Арахангельская обл",Country=cntr2},
    //            new Region {Name="Астраханская обл",Country=cntr2},
    //            new Region {Name="Белгородская обл",Country=cntr2},
    //            new Region {Name="Брянская обл",Country=cntr2},
    //            new Region {Name="Иркутская обл",Country=cntr2},
    //            new Region {Name="Ивановская обл",Country=cntr2},
    //            new Region {Name="Калининградская обл",Country=cntr2},
    //            new Region {Name="Калужская обл",Country=cntr2},
    //            new Region {Name="Кемеровская обл",Country=cntr2},
    //            new Region {Name="Кировская обл",Country=cntr2},
    //            new Region {Name="Костромская обл",Country=cntr2},
    //            new Region {Name="Курганская обл",Country=cntr2},
    //            new Region {Name="Курская обл",Country=cntr2},
    //            new Region {Name="Ленинградская обл",Country=cntr2},
    //            new Region {Name="Липецкая обл",Country=cntr2},
    //            new Region {Name="Магаданская обл",Country=cntr2},
    //            new Region {Name="Московская обл",Country=cntr2},
    //            new Region {Name="Мурманская обл",Country=cntr2},
    //            new Region {Name="Нижегородская обл",Country=cntr2},
    //            new Region {Name="Новгородская обл",Country=cntr2},
    //            new Region {Name="Новосибирская обл",Country=cntr2},
    //            new Region {Name="Омская обл",Country=cntr2},
    //            new Region {Name="Оренбургская обл",Country=cntr2},
    //            new Region {Name="Орловская обл",Country=cntr2},
    //            new Region {Name="Пензенская обл",Country=cntr2},
    //            new Region {Name="Псковская обл",Country=cntr2},
    //            new Region {Name="Ростовская обл",Country=cntr2},
    //            new Region {Name="Разянская обл",Country=cntr2},
    //            new Region {Name="Саханская обл",Country=cntr2},
    //            new Region {Name="Самарская обл",Country=cntr2},
    //            new Region {Name="Саратовская обл",Country=cntr2},
    //            new Region {Name="Смоленская обл",Country=cntr2},
    //            new Region {Name="Свердловская обл",Country=cntr2},
    //            new Region {Name="Тамбовская обл",Country=cntr2},
    //            new Region {Name="Томская обл",Country=cntr2},
    //            new Region {Name="Тверская обл",Country=cntr2},
    //            new Region {Name="Тюменская обл",Country=cntr2},
    //            new Region {Name="Ульяновская обл",Country=cntr2},
    //            new Region {Name="Владимирская обл",Country=cntr2},
    //            new Region {Name="Волгоградская обл",Country=cntr2},
    //            new Region {Name="Вологодская обл",Country=cntr2},
    //            new Region {Name="Воронежская обл",Country=cntr2},
    //            new Region {Name="Ярославская  обл",Country=cntr2},
    //        };
    //        context._Regions.AddRange(regionsUA);
    //        context._Regions.AddRange(regionsRU);
    //        context._loadingTypes.AddRange(loadingTypes);
    //        context._carTypes.AddRange(carTypes);
    //        context._Countries.Add(cntr1);
    //        context._Countries.Add(cntr2);
    //        context._vehicleTypes.AddRange(vehicleTypes);
    //        context.SaveChanges();
    //        base.Seed(context);
    //    }
    //}

}