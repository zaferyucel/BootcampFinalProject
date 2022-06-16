using BootcampFinalProject.Domain.Entities;
using BootcampFinalProject.Persistence.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Persistence.SeedData
{
    public class SeedData
    {
        public static void Initialize(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<FinalProjectDbContext>();

                context.Database.Migrate();     // migration varsa veritabanını tohumlar
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(new List<Category>()
                    {

                        new Category {Name = "Mont", Description = "Kışlık Mont/Kaban", CreatedDate = new DateTime(2022, 04, 16) },
                        new Category {Name = "Hırka ve Süveter", Description = "Hırka ve Süveter Ürünleri", CreatedDate = new DateTime(2022, 04, 16) },
                        new Category {Name = "Pijama", Description = "Rahat Pijamalar", CreatedDate =new DateTime(2022, 04, 16) },
                        new Category {Name = "Kazak", Description = "Kazak Çeşitleri", CreatedDate = new DateTime(2022, 04, 16) },
                        new Category {Name = "Gömlek", Description = "Gömlek Çeşitleri", CreatedDate = new DateTime(2022, 04, 16) },
                        new Category {Name = "Tshirt", Description = "Tshirt Çeşitleri", CreatedDate = new DateTime(2022, 04, 16) },
                        new Category {Name = "Sweatshirt", Description = "Sweatshirt Çeşitleri", CreatedDate = new DateTime(2022, 04, 16) },
                        new Category {Name = "Jean", Description = "Jean Çeşitleri", CreatedDate = new DateTime(2022, 04, 16) },
                    });
                    context.SaveChanges();
                }
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                                                
                        new Product { CategoryId = 1, Name = "Kadın Şişme Mont",Description = "Fermuar kapamalı Fermuar Cepli",  Price = 800,  CreatedDate = new DateTime(2022, 04, 16), IsOfferable=true, IsSold=false },
                        new Product { CategoryId = 1, Name = "Erkek Deri Mont",Description = "Fermuar kapamalı Fermuar Cepli",  Price = 800,  CreatedDate = new DateTime(2022, 04, 16), IsOfferable=true, IsSold=false },
                        new Product { CategoryId = 1, Name = "Erkek Deri Mont Yakalı",Description = "Dik Yaka Erkek Deri Mont", Price = 1500,  CreatedDate = new DateTime(2022, 04, 16), IsOfferable=true, IsSold=false },
                        new Product { CategoryId = 1, Name = "Erkek Şişme Mont",Description = "Erkek Şişme Mont",  Price = 600,  CreatedDate = new DateTime(2022, 04, 16), IsOfferable=true, IsSold=false },
                        new Product { CategoryId = 2, Name = "Kadın Triko Hırka",Description = "Uzun Kollu Kadın Triko Hırka",  Price = 400,  CreatedDate = new DateTime(2022, 04, 16), IsOfferable=true, IsSold=false },
                        new Product { CategoryId = 2, Name = "Kadın Süveter",Description = "Kapüşonlu Kadın Süveter", Price = 160,  CreatedDate = new DateTime(2022, 04, 16), IsOfferable=true, IsSold=false },
                        new Product { CategoryId = 3, Name = "Erkek Pijama",Description = "Erkek Düz Pijama", Price = 120,  CreatedDate = new DateTime(2022, 04, 16), IsOfferable=true, IsSold=false },
                        new Product { CategoryId = 4, Name = "Çizgili Erkek Triko Kazak",Description = "Uzun Kollu Çizgili Erkek Triko Kazak",  Price = 180,  CreatedDate = new DateTime(2022, 04, 16), IsOfferable=true, IsSold=false },
                        new Product { CategoryId = 4, Name = "Çizgili Kadın Kazak",Description = "Kalp Yaka Kolsız Kadın Blz",Price = 350, CreatedDate = new DateTime(2022, 04, 16), IsOfferable=true, IsSold=false },
                        new Product { CategoryId = 4, Name = "Renk Bloklu Uzun Kollu Kadın Bluz",Description = "Dik Yaka Erkek Deri Mont", Price = 450, CreatedDate = new DateTime(2022, 04, 16), IsOfferable=true, IsSold=false },
                        new Product { CategoryId = 5, Name = "Uzun Kollu Gömlek", Description = "Uzun kollu kareli gömlek", Price = 250,  CreatedDate = new DateTime(2022, 04, 16), IsOfferable=true, IsSold=false }
                       
                    });
                    context.SaveChanges();
                }



            }
        }
    }
    }