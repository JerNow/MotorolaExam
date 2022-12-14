USE [MotorolaExam.EntitiesDb]
GO
SET IDENTITY_INSERT [dbo].[MotorolaTeams] ON 

INSERT [dbo].[MotorolaTeams] ([Id], [Name]) VALUES (1, N'MotorolaJavaTeam')
SET IDENTITY_INSERT [dbo].[MotorolaTeams] OFF
GO
SET IDENTITY_INSERT [dbo].[MotoTeamMembers] ON 

INSERT [dbo].[MotoTeamMembers] ([Id], [Name], [YearsOfExpierience], [Specialization], [MotorolaTeamId]) VALUES (1, N'Wacław Trocki', 5, N'DevOps', 1)
INSERT [dbo].[MotoTeamMembers] ([Id], [Name], [YearsOfExpierience], [Specialization], [MotorolaTeamId]) VALUES (2, N'Michał Czereśniecki', 12, N'Frontend', 1)
INSERT [dbo].[MotoTeamMembers] ([Id], [Name], [YearsOfExpierience], [Specialization], [MotorolaTeamId]) VALUES (3, N'Gerwazy Poniatowski', 1, N'Backend Java', 1)
SET IDENTITY_INSERT [dbo].[MotoTeamMembers] OFF
GO
SET IDENTITY_INSERT [dbo].[MotoTechStacks] ON 

INSERT [dbo].[MotoTechStacks] ([Id], [Name], [Definition]) VALUES (1, N'.net', N'MAUI, EF Core')
INSERT [dbo].[MotoTechStacks] ([Id], [Name], [Definition]) VALUES (2, N'Java', N'Servlet API, JST')
INSERT [dbo].[MotoTechStacks] ([Id], [Name], [Definition]) VALUES (3, N'Python', N'NumPy, OpenCV')
INSERT [dbo].[MotoTechStacks] ([Id], [Name], [Definition]) VALUES (4, N'JavaScript', N'Polymer, VueJS')
SET IDENTITY_INSERT [dbo].[MotoTechStacks] OFF
GO
SET IDENTITY_INSERT [dbo].[MotorolaProjects] ON 

INSERT [dbo].[MotorolaProjects] ([Id], [TeamId], [Title], [Description], [MotoTechStackId], [LaunchDate]) VALUES (2, 1, N'Radio Control Center ', N'CC for american radios handled with java', 2, CAST(N'2023-09-12T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[MotorolaProjects] OFF
GO
SET IDENTITY_INSERT [dbo].[Review] ON 

INSERT [dbo].[Review] ([Id], [Content], [MotorolaProjectId]) VALUES (1, N'Planned features look good', 2)
INSERT [dbo].[Review] ([Id], [Content], [MotorolaProjectId]) VALUES (2, N'Good choice of technologies', 2)
SET IDENTITY_INSERT [dbo].[Review] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220914182029_initCreate', N'6.0.9')
GO
