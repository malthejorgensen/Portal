﻿INSERT INTO `User`(GUID, Email, DateCreated) VALUES (unhex('0000000000000000000000000000001'),'test@test.test','2000-01-01 00:00:00');
INSERT INTO `Group`(GUID,SystemPermission,Name,DateCreated) VALUES ( unhex('0000000000000000000000000000010'),255,'test group','2000-01-01 00:00:00');
INSERT INTO `Group_User_Join`(GroupGUID,UserGUID,Permission,DateCreated) VALUES 
(unhex('0000000000000000000000000000010'),unhex('0000000000000000000000000000001'),255,'2000-01-01 00:00:00');