INSERT INTO Trainers (FirstName, LastName, IsAvailable)
VALUES
('John', 'Peterson', 1),
('Maria', 'Ivanova', 1),
('David', 'Brown', 0);

INSERT INTO Members
(FirstName, LastName, TranerId, CardStatus, SubscribtionType, TotalCaloriesBurnt)
VALUES
('Alex', 'Johnson', 1, 0, 2, 0),
('Emma', 'Williams', 1, 0, 1, 0),
('Michael', 'Davis', 2, 0, 4, 0),
('Sophia', 'Miller', 3, 0, 6, 0),
('Daniel', 'Wilson', NULL, 0, 0, 0);

INSERT INTO Workouts (Name, IsCompleted, MemberId)
VALUES
('Chest Day', 1, 1),
('Leg Day', 0, 2),
('Back Workout', 1, 3),
('Cardio Session', 1, 4),
('Full Body Workout', 0, 5);

INSERT INTO Exercises (Name, CaloriesBurnt, WorkoutId)
VALUES
('Bench Press', 120, 1),
('Push Ups', 80, 1),

('Squats', 150, 2),
('Lunges', 90, 2),

('Pull Ups', 110, 3),
('Deadlift', 220, 3),

('Running', 300, 4),
('Cycling', 180, 4),

('Burpees', 140, 5),
('Jump Rope', 160, 5);