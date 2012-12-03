﻿namespace Application4Test.Domain.Repositories
{
    public interface IDogRepository
    {
        void Save(Dog dog);
        Dog Get(object id);
        void Update(Dog dog);
    }
}