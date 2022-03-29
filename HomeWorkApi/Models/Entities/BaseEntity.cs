using System;
using Homework.Api.Enums;

namespace Homework.Api.Models.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }

        public ItemState State { get; set; } = ItemState.Creted;

        public void Update(long userId)
        {
            State = ItemState.Updated;
        }

        public void Delete(long userId)
        {
            State = ItemState.Deleted;
        }
    }
}
