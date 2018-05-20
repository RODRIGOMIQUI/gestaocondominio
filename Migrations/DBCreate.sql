
CREATE TABLE `AspNetRoles` (
  `Id` VARCHAR(45) NOT NULL,
  `Name` VARCHAR(45) NULL,
  PRIMARY KEY (`Id`));
  
  
DROP TABLE AspNetUsers;
CREATE TABLE `AspNetUsers` (
	`Id`					VARCHAR(128) 	NOT NULL,
	`Hometown` 				VARCHAR(5000) 	NULL,
	`Email` 				VARCHAR(256) 	NULL,
	`EmailConfirmed` 		bit 			NOT NULL,
	`PasswordHash` 			VARCHAR(5000) 	NULL,
	`SecurityStamp` 		VARCHAR(5000) 	NULL,
	`PhoneNumber`			VARCHAR(5000) 	NULL,
	`PhoneNumberConfirmed`	bit 			NOT NULL,
	`TwoFactorEnabled` 		bit 			NOT NULL,
	`LockoutEndDateUtc` 	datetime 		NULL,
	`LockoutEnabled` 		bit 			NOT NULL,
	`AccessFailedCount` 	INT				NOT NULL,
	`UserName` 				VARCHAR(256) 	NOT NULL,
	PRIMARY KEY (`Id`)
);
  
  
DROP TABLE AspNetUserClaims;
CREATE TABLE `AspNetUserClaims` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `UserId` VARCHAR(45) NULL,
  `ClaimType` VARCHAR(100) NULL,
  `ClaimValue` VARCHAR(100) NULL,
  PRIMARY KEY (`Id`),
  FOREIGN KEY (`UserId`)
    REFERENCES `AspNetUsers` (`Id`) on delete cascade);

    
CREATE TABLE `AspNetUserLogins` (
  `UserId` VARCHAR(45) NOT NULL,
  `ProviderKey` VARCHAR(100) NULL,
  `LoginProvider` VARCHAR(100) NULL,
  FOREIGN KEY (`UserId`)
    REFERENCES `AspNetUsers` (`Id`) on delete cascade);
    
    
CREATE TABLE `AspNetUserRoles` (
  `UserId` VARCHAR(45) NOT NULL,
  `RoleId` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`UserId`, `RoleId`),
  FOREIGN KEY (`UserId`)
    REFERENCES `AspNetUsers` (`Id`) 
		on delete cascade
		on update cascade,
  FOREIGN KEY (`RoleId`)
    REFERENCES `AspNetRoles` (`Id`)
		on delete cascade
		on update cascade);