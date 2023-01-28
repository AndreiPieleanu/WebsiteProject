using LogicLayer.Enums;
using LogicLayer.Interfaces;
using LogicLayer.Models;
using LogicLayer.Models.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DALs
{
    public class NewsDal : BaseDal, INewsDal, ITagDal
    {
        private List<INews> _allNews = new List<INews>();
        private NewsCatalogue _newsCatalogue = new NewsCatalogue();

        public NewsDal(DbSettings settings) : base(settings)
        {
            FillListWithDummyData();
        }
        public void AddNewsToCatalogue(INews newsToAdd, NewsCatalogue newsCatalogue)
        {
            return;
        }

        public void AddTagToNews(string tag, INews news)
        {
            return;
        }

        public void ChangeEditedDateOfNews(DateTime newEditedDate, INews news)
        {
            return;
        }

        public void EditNewsFromCatalogue(INews updatedNews, NewsCatalogue newsCatalogue)
        {
            return;
        }

        public void EditTagOfNews(string tag, INews news)
        {
            return;
        }
        private void FillListWithDummyData()
        {
            IUser daniel = new Author(1, new Credentials("tigan@gmail.com", new Password()), new PersonalDetails("Daniel", "Calita"));
            string imgLocation = "C:\\Users\\Andrei\\Desktop\\Data\\NewsApp\\WebsiteProject\\NewsDesktop\\NewsDesktop\\Resources\\ad2.jpg";
            INews article1 = new Article(1, "Brazil airlifts starving Yanomami tribal people from jungle", "Brazil has airlifted 16 starving Yanomami tribal people to receive urgent treatment, after the government declared a medical emergency.", daniel, DateTime.Today, NewsCategory.Politics, 7, "The indigenous people live in a reserve in Brazil's northern state of Roraima.\r\n\r\nPresident Luiz Inácio Lula da Silva has accused his predecessor, far-right Jair Bolsonaro, of committing genocide against the rainforest tribe.\r\n\r\nThe government declared a medical emergency after hundreds of Yanomami children died from malnutrition.\r\n\r\nThe deaths are linked to water pollution caused by mining and logging in the densely forested area, where food insecurity is rife.\r\n\r\nOn Saturday President Lula visited Roraima, which borders Venezuela and Guyana, following reports of severe malnutrition among Yanomami children and said he was \"shocked\" by what he found.\r\n\r\n\"More than a humanitarian crisis, what I saw in Roraima was genocide: a premeditated crime against the Yanomami, committed by a government insensitive to suffering,\" he said later. \"I came here to say we are going to treat our indigenous people as human beings.\"", new NormalImage(1, 100.0, 100.0, imgLocation), new List<string> { "world", "brazil" }, new NormalImage(1, 100.0, 100.0, imgLocation));

            INews article2 = new Article(2, "Kyrylo Tymoshenko: Top Zelensky aide announces resignation", "One of Ukrainian President Volodymyr Zelensky's key aides has resigned ahead of an expected government reshuffle.", daniel, DateTime.Today, NewsCategory.War, 10, "Kyrylo Tymoshenko was the president's deputy head of office and thanked Mr Zelensky for \"the opportunity to do good deeds every day and every minute\".\r\n\r\nHe had been implicated in scandals linked to his use of expensive cars - though he denies wrongdoing.\r\n\r\nMr Zelensky has signalled that other top officials will also leave his government in the coming days.\r\n\r\nThe Ukrainian leader has said he is carrying out a series of personnel changes in government, regional authorities and the security services.\r\n\r\nLocal media reported that the departure Mr Tymoshenko - who oversaw regional policy and earlier worked on Mr Zelensky's election campaign - may be part of the president's shake-up.\r\n\r\nBut the restructure comes amid a clampdown on corruption in Ukraine, one of the EU's key demands if the country is to advance its application to join the bloc. Authorities have banned all state officials from leaving Ukraine, unless on authorised business trips.\r\n\r\nOn Monday, Ukraine's deputy infrastructure minister Vasyl Lozinskyi was fired and detained by police after being accused of accepting a bribe worth $400,000 (£320,000). He has denied the charges.", new NormalImage(1, 100.0, 100.0, imgLocation), new List<string> { "zelensky", "ukraine" }, new NormalImage(1, 100.0, 100.0, imgLocation));

            INews breakingNews1 = new BreakingNews(3, "Erdogan tells Sweden not to expect Nato bid support", "Sweden should not expect Turkey to back its Nato membership bid, Turkish president Tayyip Erdogan said on Monday, days after a copy of the Quran was burned in a Stockholm protest.", daniel, DateTime.Today.AddDays(-1), NewsCategory.Politics, 6, "Sweden applied to join Nato after Russia invaded Ukraine - but needs Turkey, already a member, to approve.\r\n\r\nKurdish protesters in Sweden hung an effigy of Mr Erdogan this month, followed by the Quran burning.\r\n\r\n\"Sweden should not expect support from us for Nato,\" Erdogan said in response.\r\n\r\n\"It is clear that those who caused such a disgrace in front of our country's embassy can no longer expect any benevolence from us regarding their application.\"\r\n\r\nSaturday's protest - but not the burning of the book itself - was given prior approval by Swedish authorities.\r\n\r\nErdogan condemned the latest protest, carried out by a far-right politician from a Danish party, as blasphemy not to be defended by free speech.\r\n\r\nThe Swedish governments also criticised the protest.\r\n\r\n\"Sweden has a far-reaching freedom of expression, but it does not imply that the Swedish government, or myself, support the opinions expressed,\" Swedish Foreign Minister Tobias Billstrom said on Saturday.\r\n\r\nResponding to Mr Erdogan's remarks on Monday, Mr Billstrom said that he wanted to understand exactly what the Turkish leader said before commenting.\r\n\r\n\"Sweden will respect the agreement that exists between Sweden, Finland and Turkey regarding our Nato membership,\" he added.", new NormalImage(1, 100.0, 100.0, imgLocation), new List<string> { "turkey", "sweden" }, new NormalImage(1, 100.0, 100.0, imgLocation));

            INews breakingNews2 = new BreakingNews(4, "Capitol rioter who posed with feet on Nancy Pelosi's desk found guilty", "A Capitol Hill rioter who posed with his feet on US Democrat Nancy Pelosi's desk during the attack on Congress has been found guilty of all charges.", daniel, DateTime.Today.AddDays(-1), NewsCategory.Politics, 15, "Richard \"Bigo\" Barnett was among the crowd of Trump supporters who stormed the building in attempt to overturn the 2020 presidential election result.\r\n\r\nHe posed for cameras after breaking into Mrs Pelosi's office and boasted of swiping an envelope before leaving.\r\n\r\nHe was armed with a stun gun and could have harmed Mrs Pelosi, officials say.\r\n\r\nA jury in Washington DC deliberated for less than three hours before convicting Barnett of all eight charges against him.\r\n\r\nHis crimes include obstruction of an official proceeding, entering and remaining in a restricted building or grounds with a deadly weapon, and theft of government property.\r\n\r\nProsecutors argued that Barnett, 62, came to Washington DC from his home in Arkansas - over 1,000 miles away (1,600km) - prepared for violence.\r\n\r\n\"We can only imagine what would have happened if (Pelosi) had been there at the time,\" federal prosecutor Alison Prout argued, according to the Associated Press.\r\n\r\nMrs Pelosi, who was Speaker of the House of Representatives at the time, was forced to flee the chamber floor with other lawmakers as protesters stormed the building.\r\n\r\nBarnett, a former firefighter, chose to testify in his own defence during the trial. He argued that he was caught up \"in the moment\" and was \"going with the flow\", according to the Associated Press.", new NormalImage(1, 100.0, 100.0, imgLocation), new List<string> { "usa", "capitol" }, new NormalImage(1, 100.0, 100.0, imgLocation));

            INews infoNews1 = new InfoNews(5, "Io volcano world comes into view of Juno probe", "Nasa's Juno probe is bearing down on Io, the most volcanically active world in the Solar System.", daniel, DateTime.Today.AddDays(-1), NewsCategory.Science, 3, "Already, the spacecraft has passed by the Jupiter moon at a distance of 80,000km, to reveal details of its hellish, lava-strewn landscape.\r\n\r\nBut Juno will get much, much nearer to Io over the course of the next year, eventually sweeping over the surface at an altitude of just 1,500km.\r\n\r\nIt's more than 20 years since we've had such an encounter with the 3,650km-wide object.\r\n\r\nA dedicated Europa mission launches in 2024. It should find the depth of the liquid ocean\r\n\"We have a number of objectives besides trying to understand the volcanoes and lava flows, and to map them,\" said Juno's principal investigator, Dr Scott Bolton from the Southwest Research Institute.\r\n\r\n\"We're also going to be looking at the gravity field, trying to understand the interior structure of Io, to see if we can constrain whether the magma that's creating all these volcanoes forms a global ocean, or whether it's spotty,\" he told BBC News.\r\n\r\nIo's volcanism is driven by its proximity to Jupiter. It means the moon is subject to immense tidal forces and heating.", new NormalImage(1, 100.0, 100.0, imgLocation), new List<string> { "space", "spacecraft" });

            INews infoNews2 = new InfoNews(6, "Nasa's Swot satellite will survey millions of rivers and lakes", "The American space agency Nasa has launched a satellite that's expected to transform our view of water on Earth.", daniel, DateTime.Today.AddDays(-6), NewsCategory.Economy, 5, "The Swot mission will map the precise height of rivers, reservoirs and lakes, and track ocean surface features at unprecedented scales.\r\n\r\nIt should improve flood and drought forecasts, and help researchers better understand how the climate is changing.\r\n\r\nBritish scientists have been asked to help set up the spacecraft using the Bristol Channel as a benchmark.\r\n\r\nThe UK researchers are putting a suite of sensors in the estuary to \"ground truth\" the observations made by the satellite as it flies overhead at an altitude of 890km (550 miles).\r\n\r\nLift-off for the Surface Water and Ocean Topography mission occurred from California. A Falcon rocket took it skyward at 03:46 local time (11:46 GMT).\r\n\r\nSwot is led principally by Nasa and Cnes, the French space agency, with contributions from the UK and Canadian space agencies.", new NormalImage(1, 100.0, 100.0, imgLocation), new List<string> { "uk", "nasa" });
            _allNews = new List<INews>()
            {
                article1,
                article2,
                breakingNews1,
                breakingNews2,
                infoNews1,
                infoNews2
            };
            foreach (INews news in _allNews)
            {
                _newsCatalogue.AddNews(news);
            }
        }
        public NewsCatalogue GetNewsCatalogue()
        {
            return _newsCatalogue;
        }

        public void RemoveNewsFromCatalogue(INews newsToRemove, NewsCatalogue newsCatalogue)
        {
            return;
        }

        public void RemoveTagFromNews(string tag, INews news)
        {
            return;
        }
        public List<NewsCategory> GetNewsCategories()
        {
            return new List<NewsCategory>()
            {
                NewsCategory.War,
                NewsCategory.Politics,
                NewsCategory.Education,
                NewsCategory.Health,
                NewsCategory.Environment,
                NewsCategory.Economy,
                NewsCategory.Entertainment,
                NewsCategory.Sport,
                NewsCategory.Cancan,
                NewsCategory.Science,
            };
        }
    }
}
