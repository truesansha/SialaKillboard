using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Siala.Domain.DataModels;

namespace Siala.Domain
{
    public class DbSeeder
    {
        private readonly ApplicationDbContext _dbContext;

        public DbSeeder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SeedAsync()
        {
            // Create the Db if it doesn't exist
            _dbContext.Database.EnsureCreated();
            // Create default Races
            if (!await _dbContext.PlayerRaces.AnyAsync())
            {
                await CreatePlayerRacesAsync();
            }

            // Create default Factions
            if (!await _dbContext.Factions.AnyAsync())
            {
                await CreateFactionsAndLocationsAsync();
            }

            // Create default Classes
            if (!await _dbContext.PlayerClasses.AnyAsync())
            {
                await CreatePlayerClassesAsync();
            }

            _dbContext.SaveChanges();
        }

        private async Task CreatePlayerRacesAsync()
        {
            List<PlayerRace> races = new List<PlayerRace>
            {
                new PlayerRace
                {
                    Name = "Dwarf",
                    Description = "Dwarves are known for their skill in warfare, their ability to withstand physical and magical punishment, their hard work, and their capacity for drinking ale."
                },
                new PlayerRace
                {
                    Name = "Elf",
                    Description = "Elves are known for their poetry, song, and magical arts, but when danger threatens they show great skill with weapons and strategy."
                },
                new PlayerRace
                {
                    Name = "Gnome",
                    Description = "Gnomes are in wide demand as alchemists, inventors, and technicians, though most prefer to remain among their own kind in simple comfort."
                },
                new PlayerRace
                {
                    Name = "Half-elf",
                    Description = "Half-elves have the curiosity and ambition of their human parent, with the refined senses and love of nature of their elven parent, though they are outsiders among both cultures."
                },
                new PlayerRace
                {
                    Name = "Half-orc",
                    Description = "Half-Orcs are the short-tempered and sullen result of human and orc pairings."
                },
                new PlayerRace
                {
                    Name = "Halfling",
                    Description = "Halflings are clever, capable, and resourceful survivors."
                },
                new PlayerRace
                {
                    Name = "Human",
                    Description = "Humans are the most adaptable of the common races."
                }
            };
            await _dbContext.PlayerRaces.AddRangeAsync(races);
        }

        private async Task CreateFactionsAndLocationsAsync()
        {
            _dbContext.Factions.Add(new Faction
            {
                Name = "Нейтральный",
                Description = "Нейтральные земли."
            });

            _dbContext.Factions.Add(new Faction
            {
                Name = "Рачье Герцогство",
                Description = "Владения Неназываемого."
            });

            _dbContext.Factions.Add(new Faction
            {
                Name = "Валиостр",
                Description = "Владения короля Сталкона."
            });

            List<Location> locations = new List<Location>
            {
                new Location
                {
                    Name = "Золотой лес",
                    FactionId = 3
                },
                new Location
                {
                    Name = "Инсанна",
                    FactionId = 2
                },
                new Location
                {
                    Name = "Авендум",
                    FactionId = 1
                }

            };
            await _dbContext.Locations.AddRangeAsync(locations);
        }

        private async Task CreatePlayerClassesAsync()
        {
            List<PlayerClass> races = new List<PlayerClass>
            {
                new PlayerClass
                {
                    Name = "Arcane Archer",
                    Description = "Master of the elven warbands, the arcane archer is a warrior skilled in using magic to supplement his combat prowess."
                },
                new PlayerClass
                {
                    Name = "Assassin",
                    Description = "The assassin is a master of dealing quick, lethal blows."
                },
                new PlayerClass
                {
                    Name = "Barbarian",
                    Description = "Barbarians are brave, even reckless warriors, and their great strength and heartiness makes them well suited for adventure."
                },
                new PlayerClass
                {
                    Name = "Bard",
                    Description = "Bards often serve as negotiators, messengers, scouts, and spies."
                },
                new PlayerClass
                {
                    Name = "Blackguard",
                    Description = "A blackguard epitomizes evil."
                },
                new PlayerClass
                {
                    Name = "Champion Of Torm",
                    Description = "Champions of Torm are mighty warriors who dedicate themselves to Torm's cause, defending holy ground, destroying enemies of the church, and slaying mythical beasts."
                },
                new PlayerClass
                {
                    Name = "Cleric",
                    Description = "Clerics act as intermediaries between the earthly and the divine (or infernal) worlds."
                },
                new PlayerClass
                {
                    Name = "Druid",
                    Description = "Druids are divine spellcasters who receive their spells from nature, not the gods."
                },
                new PlayerClass
                {
                    Name = "Dwarven Defender",
                    Description = "The defender is a sponsored champion of dwarven cause, a dwarven aristocrat, a dwarven deity or the dwarven way of life."
                },
                new PlayerClass
                {
                    Name = "Fighter",
                    Description = "Fighters can be many things, from soldiers to criminal enforcers."
                },
                new PlayerClass
                {
                    Name = "Monk",
                    Description = "Monks are versatile warriors skilled at fighting without weapons or armor."
                },
                new PlayerClass
                {
                    Name = "Paladin",
                    Description = "Paladins take their adventures seriously, and even a mundane mission is, in the heart of the paladin, a personal test - an opportunity to demonstrate bravery, to learn tactics, and to do good in the world."
                },
                new PlayerClass
                {
                    Name = "Pale Master",
                    Description = "Necromancy is usually a poor choice for arcane spellcasters."
                },
                new PlayerClass
                {
                    Name = "Ranger",
                    Description = "Rangers are skilled stalkers and hunters who make their home in the wilderness."
                },
                new PlayerClass
                {
                    Name = "Red Dragon Disciple",
                    Description = "Red dragon disciple is a class that represents a wielder of magic discovering and embracing a draconic heritage, eventually gaining some features of dragons."
                },
                new PlayerClass
                {
                    Name = "Rogue",
                    Description = "Rogues have little in common with each other."
                },
                new PlayerClass
                {
                    Name = "Shadowdancer",
                    Description = "Shadowdancers operate in the border between light and darkness."
                },
                new PlayerClass
                {
                    Name = "Shifter",
                    Description = "A shifter has no form they call their own."
                },
                new PlayerClass
                {
                    Name = "Sorcerer",
                    Description = "Sorcerers are arcane spellcasters who manipulate magic energy with imagination and talent rather than studious discipline."
                },
                new PlayerClass
                {
                    Name = "Weapon Master",
                    Description = "For the weapon master, perfection is found in the mastery of a single melee weapon."
                },
                new PlayerClass
                {
                    Name = "Wizard",
                    Description = "Wizards are arcane spellcasters who depend on intensive study to create their magic."
                },
                new PlayerClass
                {
                    Name = "Harper Scout",
                    Description = "The Harpers are a secret society."
                }
            };

            await _dbContext.PlayerClasses.AddRangeAsync(races);
        }
    }
}