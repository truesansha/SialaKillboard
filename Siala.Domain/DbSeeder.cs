using System;
using System.Collections.Generic;
using System.Linq;
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

#if DEBUG
            // Create temp players
            if (!await _dbContext.Players.AnyAsync())
            {
                await GenerateTempPlayers();
            }

            if (!await _dbContext.Kills.AnyAsync())
            {
                await GenerateTempKills();
            }
#endif

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

        private async Task GenerateTempPlayers()
        {
            List<String> dwarfNames = new List<String>
            {
                "Боин",
                "Дели",
                "Фифур",
                "Норин",
                "Терин",
                "Бобур",
                "Фофур",
                "Дали",
                "Неин",
                "Рофур",
                "Рабур",
                "Бомфур",
                "Дели",
                "Теин",
                "Бофур",
                "Дафур"
            };

            List<String> elfNames = new List<String>
            {
                "Эарранад",
                "Эаррилир",
                "Эаррохад",
                "Эйарод",
                "Эйкилеф",
                "Эланан",
                "Элвэ",
                "Элгинор",
                "Элгорм",
                "Элгорм",
                "Элрафир",
                "Элрин",
                "Эльанил",
                "Эльвэ",
                "Эльгорм",
                "Эльлинан",
                "Эльлор",
                "Моран",
                "Моранен",
                "Морвенинг",
                "Морда",
                "Мордаинг",
                "Мордисилас",
                "Мордриэнь",
                "Мориен",
                "Мориинг",
                "Морлот",
                "Морринилас"
            };

            List<String> gnomeNames = new List<String>
            {
                "Какиника",
                "Баивсена",
                "Шиорлика",
                "Доидин",
                "Заадка",
                "Миэтсена",
                "Киидса",
                "Лависа",
                "Кивиин",
                "Довиса"
            };

            List<String> halfelfNames = new List<String>
            {
                "Наиселл",
                "Натаниэль",
                "Нокс",
                "Нур",
                "Ниа"
            };

            List<String> halforcNames = new List<String>
            {
                "Изанк",
                "Ралг",
                "Гогдиш",
                "Гакар",
                "Фалаг",
                "Морт",
                "Сугак",
                "Нузаг",
                "Нигак",
                "Прарк",
                "Хагниш",
                "Агизаг",
                "Дузык"
            };

            List<String> halflingNames = new List<String>
            {
                "Титаний",
                "Тоберон",
                "Тиберий",
                "Тор",
                "Тейлор",
                "Ферммар",
                "Фаавел",
                "Феофил",
                "Фиделий",
                "Феб"
            };

            List<String> humanNames = new List<String>
            {
                "Медор",
                "Освир",
                "Хавирлеб",
                "Метелитар",
                "Араодкар",
                "Бароил",
                "Осрорн",
                "Исвиртур",
                "Эарагбар",
                "Исротур",
                "Элдор",
                "Эарор",
                "Босил",
                "Киаглас",
                "Эаррон",
                "Хавиртур"
            };

            List<Player> players = new List<Player>();

            players.AddRange(getDwarfs(dwarfNames));
            players.AddRange(getElfs(elfNames));
            players.AddRange(getGnomes(gnomeNames));
            players.AddRange(getHalfElfes(halfelfNames));
            players.AddRange(getHalfOrcs(halforcNames));
            players.AddRange(getHalflings(halflingNames));
            players.AddRange(getHumans(humanNames));

            await _dbContext.Players.AddRangeAsync(players);
        }

        private async Task GenerateTempKills()
        {
            List<Player> playersValiostr = await _dbContext.Players.Where(p => p.FactionId == 1).ToListAsync();
            Int32 vCount = playersValiostr.Count;
            List<Player> playersInsanna = await _dbContext.Players.Where(p => p.FactionId == 2).ToListAsync();
            Int32 iCount = playersInsanna.Count;
            List<Player> players = await _dbContext.Players.ToListAsync();
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            foreach (Player player in players)
            {
                Int32 killNumber = rnd.Next(1, 25);
                for (Int32 i = 0; i < killNumber; i++)
                {
                    Player fbPlayer = player.FactionId == 1 ? playersInsanna[rnd.Next(0, iCount)] : playersValiostr[rnd.Next(0, vCount)];
                    EntityEntry<Kill> kill = _dbContext.Kills.Add(new Kill
                    {
                        FinalBlowPlayerId = fbPlayer.Id,
                        KillTime = new DateTime(2017, rnd.Next(1, 7), rnd.Next(1, 29)),
                        LocationId = rnd.Next(1, 4),
                        VictimClass1Id = player.Class1Id,
                        VictimClass1Level = player.Class1Level,
                        VictimFactionId = player.FactionId,
                        VictimId = player.Id,
                        VictimRaceId = player.RaceId,
                        DamageTaken = 0
                    });

                    _dbContext.SaveChanges();

                    Int32 involvedCount = rnd.Next(0, 5);

                    _dbContext.InvolvedPlayers.Add(new InvolvedPlayer
                    {
                        AttackerClass1Id = fbPlayer.Class1Id,
                        AttackerClass1Level = 40,
                        AttackerFactionId = fbPlayer.FactionId,
                        AttackerRaceId = fbPlayer.RaceId,
                        AttackerId = fbPlayer.Id,
                        DamageDone = rnd.Next(100, 1000),
                        KillId = kill.Entity.Id
                    });

                    List<Int32> involvedIds = new List<Int32>();
                    involvedIds.Add(fbPlayer.Id);
                    for (Int32 j = 0; j < involvedCount; j++)
                    {
                        Player randomAttacker = player.FactionId == 1 ? playersInsanna[rnd.Next(0, iCount)] : playersValiostr[rnd.Next(0, vCount)];
                        if (!involvedIds.Contains(randomAttacker.Id))
                        {
                            _dbContext.InvolvedPlayers.Add(new InvolvedPlayer
                            {
                                AttackerClass1Id = randomAttacker.Class1Id,
                                AttackerClass1Level = 40,
                                AttackerFactionId = randomAttacker.FactionId,
                                AttackerRaceId = randomAttacker.RaceId,
                                AttackerId = randomAttacker.Id,
                                DamageDone = rnd.Next(1, 200),
                                KillId = kill.Entity.Id
                            });
                        }
                    }
                }
                
            }
        }

        private List<Player> getDwarfs(List<String> names)
        {
            List<Player> result = new List<Player>();

            foreach (String name in names)
            {
                Random rnd = new Random(Guid.NewGuid().GetHashCode());

                Int32 classId = rnd.Next(1, 23);
                Int32 factionId = rnd.Next(1, 100) % 2 == 0 ? 1 : 2;

                result.Add(new Player
                {
                    Class1Id = classId,
                    Class1Level = 40,
                    FactionId = factionId,
                    Name = name,
                    RaceId = 7
                });
            }

            return result;
        }

        private List<Player> getElfs(List<String> names)
        {
            List<Player> result = new List<Player>();

            foreach (String name in names)
            {
                Random rnd = new Random(Guid.NewGuid().GetHashCode());

                Int32 classId = rnd.Next(1, 23);
                Int32 factionId = rnd.Next(1, 100) % 2 == 0 ? 1 : 2;

                result.Add(new Player
                {
                    Class1Id = classId,
                    Class1Level = 40,
                    FactionId = factionId,
                    Name = name,
                    RaceId = 6
                });
            }

            return result;
        }

        private List<Player> getGnomes(List<String> names)
        {
            List<Player> result = new List<Player>();

            foreach (String name in names)
            {
                Random rnd = new Random(Guid.NewGuid().GetHashCode());

                Int32 classId = rnd.Next(1, 23);
                Int32 factionId = rnd.Next(1, 100) % 2 == 0 ? 1 : 2;

                result.Add(new Player
                {
                    Class1Id = classId,
                    Class1Level = 40,
                    FactionId = factionId,
                    Name = name,
                    RaceId = 5
                });
            }

            return result;
        }

        private List<Player> getHalfElfes(List<String> names)
        {
            List<Player> result = new List<Player>();

            foreach (String name in names)
            {
                Random rnd = new Random(Guid.NewGuid().GetHashCode());

                Int32 classId = rnd.Next(1, 23);
                Int32 factionId = rnd.Next(1, 100) % 2 == 0 ? 1 : 2;

                result.Add(new Player
                {
                    Class1Id = classId,
                    Class1Level = 40,
                    FactionId = factionId,
                    Name = name,
                    RaceId = 4
                });
            }

            return result;
        }

        private List<Player> getHalfOrcs(List<String> names)
        {
            List<Player> result = new List<Player>();

            foreach (String name in names)
            {
                Random rnd = new Random(Guid.NewGuid().GetHashCode());

                Int32 classId = rnd.Next(1, 23);
                Int32 factionId = rnd.Next(1, 100) % 2 == 0 ? 1 : 2;

                result.Add(new Player
                {
                    Class1Id = classId,
                    Class1Level = 40,
                    FactionId = factionId,
                    Name = name,
                    RaceId = 3
                });
            }

            return result;
        }

        private List<Player> getHalflings(List<String> names)
        {
            List<Player> result = new List<Player>();

            foreach (String name in names)
            {
                Random rnd = new Random(Guid.NewGuid().GetHashCode());

                Int32 classId = rnd.Next(1, 23);
                Int32 factionId = rnd.Next(1, 100) % 2 == 0 ? 1 : 2;

                result.Add(new Player
                {
                    Class1Id = classId,
                    Class1Level = 40,
                    FactionId = factionId,
                    Name = name,
                    RaceId = 2
                });
            }

            return result;
        }

        private List<Player> getHumans(List<String> names)
        {
            List<Player> result = new List<Player>();

            foreach (String name in names)
            {
                Random rnd = new Random(Guid.NewGuid().GetHashCode());

                Int32 classId = rnd.Next(1, 23);
                Int32 factionId = rnd.Next(1, 100) % 2 == 0 ? 1 : 2;

                result.Add(new Player
                {
                    Class1Id = classId,
                    Class1Level = 40,
                    FactionId = factionId,
                    Name = name,
                    RaceId = 1
                });
            }

            return result;
        }
    }
}