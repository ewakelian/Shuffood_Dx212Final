using Google.Cloud.Firestore;

namespace Shuffood.Firebase
{
    [FirestoreData]
    public class FoodItem
    {
        [FirestoreProperty]
        public string ID { get; set; }

        [FirestoreProperty]
        public string Image { get; set; }

        [FirestoreProperty]
        public string Name { get; set; }

        [FirestoreProperty]
        public string Description { get; set; }

        [FirestoreProperty]
        public string Nation { get; set; }
    }
}
