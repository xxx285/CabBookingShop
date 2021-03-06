USE [xuyang.CabBookingShop]
GO
SET IDENTITY_INSERT [dbo].[Place] ON 

INSERT [dbo].[Place] ([PlaceId], [PlaceName]) VALUES (1, N'Raleigh, NC')
INSERT [dbo].[Place] ([PlaceId], [PlaceName]) VALUES (2, N'Cary, NC')
INSERT [dbo].[Place] ([PlaceId], [PlaceName]) VALUES (4, N'Carson, LA')
INSERT [dbo].[Place] ([PlaceId], [PlaceName]) VALUES (5, N'Manhattan, NY')
INSERT [dbo].[Place] ([PlaceId], [PlaceName]) VALUES (51, N'Richmond, VA')
INSERT [dbo].[Place] ([PlaceId], [PlaceName]) VALUES (52, N'Virginia Beach, VA')
INSERT [dbo].[Place] ([PlaceId], [PlaceName]) VALUES (53, N'Washington, DC')
SET IDENTITY_INSERT [dbo].[Place] OFF
GO
SET IDENTITY_INSERT [dbo].[CabType] ON 

INSERT [dbo].[CabType] ([CabTypeId], [CabTypeName]) VALUES (1, N'Ford Fiesta')
INSERT [dbo].[CabType] ([CabTypeId], [CabTypeName]) VALUES (2, N'Ford Focus')
INSERT [dbo].[CabType] ([CabTypeId], [CabTypeName]) VALUES (3, N'Honda Civic')
INSERT [dbo].[CabType] ([CabTypeId], [CabTypeName]) VALUES (4, N'Maruti Suzuki Swift')
INSERT [dbo].[CabType] ([CabTypeId], [CabTypeName]) VALUES (5, N'Datsun GO+')
INSERT [dbo].[CabType] ([CabTypeId], [CabTypeName]) VALUES (6, N'Volvo S60 Cross Country')
INSERT [dbo].[CabType] ([CabTypeId], [CabTypeName]) VALUES (21, N'BMW i8')
INSERT [dbo].[CabType] ([CabTypeId], [CabTypeName]) VALUES (22, N'SUV x1')
SET IDENTITY_INSERT [dbo].[CabType] OFF
GO
SET IDENTITY_INSERT [dbo].[BookingHistory] ON 

INSERT [dbo].[BookingHistory] ([Id], [Email], [BookingDate], [BookingTime], [FromPlaceId], [ToPlaceId], [PickUpAddress], [Landmark], [PickupDate], [PickupTime], [CabTypeId], [ContactNo], [Status], [CompTime], [Charge], [Feedback]) VALUES (19, N'xyangnc@gmail.com11', CAST(N'2021-03-04' AS Date), N'00:54', 4, 1, N'626 CENTENNIAL VIEW LN', N'tower', CAST(N'2021-03-05' AS Date), N'00:57', 1, N'312-432-4444', N'completed', N'00:00', 823.2300, N'Good Experience')
INSERT [dbo].[BookingHistory] ([Id], [Email], [BookingDate], [BookingTime], [FromPlaceId], [ToPlaceId], [PickUpAddress], [Landmark], [PickupDate], [PickupTime], [CabTypeId], [ContactNo], [Status], [CompTime], [Charge], [Feedback]) VALUES (20, N'xyangnc@gmail.com', CAST(N'2021-03-05' AS Date), N'03:39', 5, 52, N'626 CENTENNIAL VIEW LN', N'River', CAST(N'2021-03-06' AS Date), N'03:41', 21, N'324-422-4244', N'completed', N'03:43', 10.0000, N'Nice Car')
SET IDENTITY_INSERT [dbo].[BookingHistory] OFF
GO
SET IDENTITY_INSERT [dbo].[Bookings] ON 

INSERT [dbo].[Bookings] ([Id], [Email], [BookingDate], [BookingTime], [FromPlaceId], [ToPlaceId], [PickUpAddress], [Landmark], [PickupDate], [PickupTime], [CabTypeId], [ContactNo], [Status]) VALUES (7, N'xyangnc@gmail.com', CAST(N'2021-03-04' AS Date), N'14:58', 2, 4, N'626 CENTENNIAL VIEW LN', N'Red Roof', CAST(N'2021-03-25' AS Date), N'05:59', 22, N'123-456-7890', N'pending')
INSERT [dbo].[Bookings] ([Id], [Email], [BookingDate], [BookingTime], [FromPlaceId], [ToPlaceId], [PickUpAddress], [Landmark], [PickupDate], [PickupTime], [CabTypeId], [ContactNo], [Status]) VALUES (9, N'xyangnc@gmail.com', CAST(N'2021-01-05' AS Date), N'03:32', 53, 5, N'514 Daniels St #188', N'Burger King', CAST(N'2021-03-03' AS Date), N'15:33', 6, N'845-321-2525', N'waiting to be picked')
INSERT [dbo].[Bookings] ([Id], [Email], [BookingDate], [BookingTime], [FromPlaceId], [ToPlaceId], [PickUpAddress], [Landmark], [PickupDate], [PickupTime], [CabTypeId], [ContactNo], [Status]) VALUES (10, N'12341234@text.com', CAST(N'2020-07-02' AS Date), N'03:34', 4, 51, N'ABC Street', N'park', CAST(N'2020-11-24' AS Date), N'03:36', 22, N'341-422-6565', N'denied')
INSERT [dbo].[Bookings] ([Id], [Email], [BookingDate], [BookingTime], [FromPlaceId], [ToPlaceId], [PickUpAddress], [Landmark], [PickupDate], [PickupTime], [CabTypeId], [ContactNo], [Status]) VALUES (11, N'fake@ws.com', CAST(N'2021-02-06' AS Date), N'15:36', 52, 53, N'2413 FAIRWAY DR APT D', N'Apartment', CAST(N'2021-03-19' AS Date), N'04:36', 5, N'234-543-5555', N'picked')
SET IDENTITY_INSERT [dbo].[Bookings] OFF
GO
