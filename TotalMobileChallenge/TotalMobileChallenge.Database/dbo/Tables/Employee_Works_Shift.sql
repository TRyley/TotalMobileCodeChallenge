CREATE TABLE [dbo].[Employee_Works_Shift] (
    [Employee_ID] INT NOT NULL,
    [Shift_ID]    INT NOT NULL,
    CONSTRAINT [FK_Employee_Works_Shift_Employee] FOREIGN KEY ([Employee_ID]) REFERENCES [dbo].[Employee] ([Employee_ID]),
    CONSTRAINT [FK_Employee_Works_Shift_Shifts] FOREIGN KEY ([Shift_ID]) REFERENCES [dbo].[Shifts] ([Shift_ID])
);

