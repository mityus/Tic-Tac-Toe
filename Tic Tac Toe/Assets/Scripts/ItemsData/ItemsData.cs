using System.ComponentModel.Design;
using Services;

namespace ItemsData
{
    public class ItemsData
    {
        public ItemsDictionaryService MatchesPositionsList { get; }
        public ItemsDictionaryService ItemsDictionary { get; }

        public ItemsData(ItemsDictionaryService matchesPositionsList, ItemsDictionaryService itemsDictionary)
        {
            MatchesPositionsList = matchesPositionsList;
            ItemsDictionary = itemsDictionary;
        }
    }
}