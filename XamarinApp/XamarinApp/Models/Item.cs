using System;
using Realms;

namespace XamarinApp
{
    public class Item : RealmObject
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }
}
