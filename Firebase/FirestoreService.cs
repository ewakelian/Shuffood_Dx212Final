using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace Shuffood.Firebase
{
    public class FirestoreService
    {
        private FirestoreDb db;
        public string StatusMessage;

        public FirestoreService()
        {
            SetupFireStore().Wait();
        }

        private async Task EnsureInitializedAsync()
        {
            if (db == null)
            {
                await SetupFireStore();
            }
        }

        private async Task SetupFireStore()
        {
            if (db == null)
            {
                try
                {
                    var stream = await FileSystem.OpenAppPackageFileAsync("shuffood-98d54-firebase-adminsdk-s5mcg-0d340d4d9d.json");
                    using (var reader = new StreamReader(stream))
                    {
                        var contents = reader.ReadToEnd();
                        db = new FirestoreDbBuilder
                        {
                            ProjectId = "shuffood-98d54",
                            JsonCredentials = contents
                        }.Build();
                    }
                }
                catch (Exception ex)
                {
                    StatusMessage = $"Error setting up Firestore: {ex.Message}";
                    throw;
                }
            }
        }



        public async Task<List<FoodItem>> GetFoodByNationAsync(string nation)
        {
            try
            {
                await EnsureInitializedAsync();

                var query = string.IsNullOrEmpty(nation)
                    ? db.Collection("FoodItem")
                    : db.Collection("FoodItem").WhereEqualTo("Nation", nation);

                var snapshot = await query.GetSnapshotAsync();
                return snapshot.Documents.Select(doc => doc.ConvertTo<FoodItem>()).ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error fetching food items: {ex.Message}";
                throw;
            }
        }

    }
}