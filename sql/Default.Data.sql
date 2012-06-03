USE Portal;

INSERT INTO Permission(TableIdentifier,Permission,Name,Description)VALUES('Group', '1', 'DELETE', 'Permission to Delete Group' );
INSERT INTO Permission(TableIdentifier,Permission,Name,Description)VALUES('Group', '2', 'UPDATE', 'Permission to Update Group');
INSERT INTO Permission(TableIdentifier,Permission,Name,Description)VALUES('Group', '4', 'GET', 'Permission to Get Group');
INSERT INTO Permission(TableIdentifier,Permission,Name,Description)VALUES('Group', '8', 'ADD_USER', 'Permission to Add a User to the group');
INSERT INTO Permission(TableIdentifier,Permission,Name,Description)VALUES('Group', '16', 'LIST_USER', 'Permission to list users in the group');
INSERT INTO Permission(TableIdentifier,Permission,Name,Description)VALUES('Subscription', '1', 'CREATE_USER', 'Permission to Create new users');
INSERT INTO Permission(TableIdentifier,Permission,Name,Description)VALUES('Subscription', '2', 'GET', 'Permission to Get Subscription');
INSERT INTO Permission(TableIdentifier,Permission,Name,Description)VALUES('Subscription', '4', 'DELETE', 'Permission to Delete Subscription');
INSERT INTO Permission(TableIdentifier,Permission,Name,Description)VALUES('Subscription', '8', 'UPDATE', 'Permission to Update Subscription');
INSERT INTO Permission(TableIdentifier,Permission,Name,Description)VALUES('Subscription', '16', 'MANAGE', 'Permission to Manage Subscription');
INSERT INTO Permission(TableIdentifier,Permission,Name,Description)VALUES('System', '1', 'CREATE_GROUP', 'Permission to Create a Group');
INSERT INTO Permission(TableIdentifier,Permission,Name,Description)VALUES('System', '2', 'CREATE_SUBSCRIPTION', 'Permission to Create a Subscription');
INSERT INTO Permission(TableIdentifier,Permission,Name,Description)VALUES('System', '4', 'MANAGE', 'Permissoin to Manage the system');