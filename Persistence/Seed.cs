using Domain.Entities.Systems;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            /*if (!context.Faculties.Any())
            {
                
            }*/

            var faculites = new List<Faculty>
                {
                    new Faculty
                    {
                        Id = 1,
                        TitleKz = "Сәулет, Құрылыс және Көлік",
                        TitleRu = "Архитектура, Строительство и Транспорт",
                        TitleEn = "Architecture, Construction and Transport"
                    },
                    new Faculty
                    {
                        Id = 2,
                        TitleKz = "Ветеринарлық клиника",
                        TitleRu = "Ветеренарная клиника",
                        TitleEn = "Veterinary clinic"
                    },
                };
            await context.Faculties.AddRangeAsync(faculites);

            var departments = new List<Department>
                {
                    new Department
                    {
                        Id = 1,
                        FacultyId = 1,
                        TitleKz = "Құрылыс және құрылыс материалдары",
                        TitleRu = "Строительство и строительные материалы",
                        TitleEn = "Building and Building Materials",
                    }
                };
            await context.Departments.AddRangeAsync(departments);

            var professions = new List<Profession>
                {
                    new Profession
                    {
                        Id = 1,
                        DepartmentId = 1,
                        Code = "B074",
                        TitleKz = "Қала құрылысы, құрылыс жұмыстары және азаматтық құрылыс",
                        TitleRu = "Градостроительство, строительные работы и гражданское строительство",
                        TitleEn = "Urban planning, construction works and civil engineering"
                    }
                };
            await context.AddRangeAsync(professions);

            var roles = new List<Role>
                {
                    new Role
                    {
                        Id = 1,
                        TitleKz = "Супер Администратор",
                        TitleRu = "Супер Администратор",
                        TitleEn = "Super Administrator",
                    },
                    new Role
                    {
                        Id = 2,
                        TitleKz = "Администратор",
                        TitleRu = "Администратор",
                        TitleEn = "Administrator",
                    },
                    new Role
                    {
                        Id = 3,
                        TitleKz = "Эдвайзер",
                        TitleRu = "Эдвайзер",
                        TitleEn = "Advisor",
                    },
                    new Role
                    {
                        Id = 4,
                        TitleKz = "Мұғалім",
                        TitleRu = "Преподаватель",
                        TitleEn = "Teacher",
                    },
                    new Role
                    {
                        Id = 5,
                        TitleKz = "Студент",
                        TitleRu = "Студент",
                        TitleEn = "Student",
                    }
                };
            await context.Roles.AddRangeAsync(roles);

            var specializations = new List<Specialization>
                {
                    new Specialization
                    {
                        Id = 1,
                        DepartmentId = 1,
                        ProfessionId = 1,
                        Code = "6B07340",
                        TitleKz = "Құрылыс материалдары, бұйымдары мен конструкциялар өндірісі",
                        TitleRu = "Производство строительных материалов, изделий и конструкций",
                        TitleEn = "Production of building materials, products and structures",
                    }
                };
            await context.AddRangeAsync(specializations);

            var academicDegrees = new List<AcademicDegree>
                {
                    new AcademicDegree
                    {
                        Id = 1,
                        TitleKz = "Бакалавр",
                        TitleRu = "Бакалавр",
                        TitleEn = "Bachelor"
                    },
                    new AcademicDegree
                    {
                        Id = 2,
                        TitleKz = "Ғылыми-педагогикалық бағыт бойынша Магистрант",
                        TitleRu = "Магистрант по научно-педагогическому направлению",
                        TitleEn = "Master's degree in scientific and pedagogical direction"
                    }
                };
            await context.AddRangeAsync(academicDegrees);

            var languages = new List<Language>
                {
                    new Language
                    {
                        Id = 1,
                        TitleKz = "Қазақ",
                        TitleRu = "Казахский",
                        TitleEn = "Kazakh"
                    },
                    new Language
                    {
                        Id = 2,
                        TitleKz = "Орыс",
                        TitleRu = "Русский",
                        TitleEn = "Russian"
                    }
                };
            await context.AddRangeAsync(languages);

            var academicYears = new List<AcademicYear>
                {
                    new AcademicYear
                    {
                        Id = 1,
                        Year = "2021-2022"
                    },
                    new AcademicYear
                    {
                        Id = 2,
                        Year = "2022-2023"
                    }
                };
            await context.AddRangeAsync(academicYears);

            var weeks = new List<Week>
                {
                    new Week
                    {
                        Id = 1,
                        TitleKz = "1 апта",
                        TitleRu = "1 неделя",
                        TitleEn = "1 week"
                    },
                    new Week
                    {
                        Id = 2,
                        TitleKz = "2 апта",
                        TitleRu = "2 неделя",
                        TitleEn = "2 week"
                    },
                    new Week
                    {
                        Id = 3,
                        TitleKz = "3 апта",
                        TitleRu = "3 неделя",
                        TitleEn = "3 week"
                    },
                    new Week
                    {
                        Id = 4,
                        TitleKz = "4 апта",
                        TitleRu = "4 неделя",
                        TitleEn = "4 week"
                    },
                    new Week
                    {
                        Id = 5,
                        TitleKz = "5 апта",
                        TitleRu = "5 неделя",
                        TitleEn = "5 week"
                    },
                    new Week
                    {
                        Id = 6,
                        TitleKz = "6 апта",
                        TitleRu = "6 неделя",
                        TitleEn = "6 week"
                    },
                    new Week
                    {
                        Id = 7,
                        TitleKz = "7 апта",
                        TitleRu = "7 неделя",
                        TitleEn = "7 week"
                    },
                    new Week
                    {
                        Id = 8,
                        TitleKz = "8 апта",
                        TitleRu = "8 неделя",
                        TitleEn = "8 week"
                    },
                    new Week
                    {
                        Id = 9,
                        TitleKz = "9 апта",
                        TitleRu = "9 неделя",
                        TitleEn = "9 week"
                    },
                    new Week
                    {
                        Id = 10,
                        TitleKz = "10 апта",
                        TitleRu = "10 неделя",
                        TitleEn = "10 week"
                    },
                    new Week
                    {
                        Id = 11,
                        TitleKz = "11 апта",
                        TitleRu = "11 неделя",
                        TitleEn = "11 week"
                    },
                    new Week
                    {
                        Id = 12,
                        TitleKz = "12 апта",
                        TitleRu = "12 неделя",
                        TitleEn = "12 week"
                    },
                    new Week
                    {
                        Id = 13,
                        TitleKz = "13 апта",
                        TitleRu = "13 неделя",
                        TitleEn = "13 week"
                    },
                    new Week
                    {
                        Id = 14,
                        TitleKz = "14 апта",
                        TitleRu = "14 неделя",
                        TitleEn = "14 week"
                    },
                    new Week
                    {
                        Id = 15,
                        TitleKz = "15 апта",
                        TitleRu = "15 неделя",
                        TitleEn = "15 week"
                    },
                };
            await context.AddRangeAsync(weeks);

            var exercises = new List<Exercise>
            {
                new Exercise { Id = 1, TitleKz = "Реферат", TitleRu = "Реферат", TitleEn = "Essay"},
                new Exercise { Id = 2, TitleKz = "1 аралық тапсырма", TitleRu = "1 рубежное задание", TitleEn = "1 milestone assignment"},
                new Exercise { Id = 3, TitleKz = "2 аралық тапсырма", TitleRu = "2 рубежное задание", TitleEn = "2 milestone assignment"},
            };
            await context.AddRangeAsync(exercises);

            await context.SaveChangesAsync();
        }
    }
}
