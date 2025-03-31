﻿using GymApp.Domain.TrainerAggregate;
using GymApp.Domain.UnitTests.TestConstants;

namespace GymApp.Domain.UnitTests.TestUtils.Trainers;

public static class TrainerFactory
{
    public static Trainer CreateTrainer(
        Guid? userId = null,
        Guid? id = null)
    {
        return new Trainer(
            userId: userId ?? Constants.User.Id,
            id: id ?? Constants.Trainer.Id);
    }
}
