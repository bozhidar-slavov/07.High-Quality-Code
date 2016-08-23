namespace FormattingCSharp
{
    using System;
    using Wintellect.PowerCollections;

    public class EventHolder
    {
        private MultiDictionary<string, Event> title = new MultiDictionary<string, Event>(true);
        private OrderedBag<Event> date = new OrderedBag<Event>();

        public void AddEvent(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);
            this.title.Add(title.ToLower(), newEvent);
            this.date.Add(newEvent);
            Messages.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string deleteThisTitle = titleToDelete.ToLower();
            int removed = 0;
            foreach (var eventToRemove in this.title[deleteThisTitle])
            {
                removed++;
                this.date.Remove(eventToRemove);
            }

            this.title.Remove(deleteThisTitle);
            Messages.EventDeleted(removed);
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View eventsToShow = this.date.RangeFrom(new Event(date, string.Empty, string.Empty), true);
            int showed = 0;
            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }

                Messages.PrintEvent(eventToShow);
                showed++;
            }

            if (showed == 0)
            {
                Messages.NoEventsFound();
            }
        }
    }
}
