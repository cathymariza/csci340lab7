using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HobbiesRP.Data;
using System;
using System.Linq;

namespace HobbiesRP.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new HobbiesRPContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<HobbiesRPContext>>()))
            {
                // Look for any movies.
                if (context.Hobby.Any())
                {
                    return;   // DB has been seeded
                }

                context.Hobby.AddRange(
                    new Hobby
                    {
                        Name = "Dancing",
                        HoursperWeek = "Fifteen",
                        Activities = "Romantic Comedy",
                        Recommendation = "Dance Flex by Kizz Daniel"
                    },

                    new Hobby
                    {
                        Name = "Listening to Music",
                        HoursperWeek = "Ten",
                        Activities = "Take at least an hour everyday and listen to my favorite songs",
                        Recommendation = "Listen to the Adele's latest song"
                    },
                    new Hobby
                    {
                        Name = "Writing",
                        HoursperWeek = "three",
                        Activities = "Writing at least three hundred words every week",
                        Recommendation = "Learn and apply a new writing tip every month"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}