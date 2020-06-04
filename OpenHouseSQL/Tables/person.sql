SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS person;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `person` (
	`personId` INT NOT NULL AUTO_INCREMENT,
	`firstName` VARCHAR(100),
	`middleName` VARCHAR(100),
	`surname` VARCHAR(100),
	`titleId` INT,
	`dateOfBirth` date,
	`telephone` VARCHAR(20),
	`email` VARCHAR(500),
	`nationalityId` INT,
	`nextOfKinFrstName` VARCHAR(100),
	`nextOfKinSurname` VARCHAR(100),
	`nextOfKinTelephone` VARCHAR(20),
	`terminationDate` datetime,
	`terminationReasonId` VARCHAR(5),
	`updatedByUserID` INT,
	`updatedDT` DATETIME,
	`createdByUserID` INT,
	`createdDT` DATETIME,
	PRIMARY KEY(`personId`),
	FOREIGN KEY (`titleId`) REFERENCES title(`titleId`),
	FOREIGN KEY (`nationalityId`) REFERENCES nationality(`nationalityId`)
)

COLLATE='utf8_general_ci'
ENGINE=InnoDB
;
SET @currDate = CURDATE();

INSERT INTO person VALUES(NULL,'Ross',NULL,'Ballantine',3,'1991-08-14','07446133733','M1610679@middlesbro.ac.uk',27,'John','Ballantine','07116123789',NULL,NULL,1,CURDATE(),1,CURDATE());
INSERT INTO person VALUES(NULL,'Philip','Marie','Mitchel',3,'1968-04-16','07246133723','pmitchel@middlesbro.ac.uk',27,'Steve','Mitchel','07116123789',NULL,NULL,1,CURDATE(),1,CURDATE());
INSERT INTO person VALUES(NULL,'Pat',NULL,'Mitchel',4,'1972-01-13','07456133743','pmmitchel9@middlesbro.ac.uk',27,'Philip','Mitchel','07116123789',NULL,NULL,1,CURDATE(),1,CURDATE());
INSERT INTO person VALUES(NULL,'Shaun',NULL,'Mitchel',3,'2012-07-12',NULL,NULL,27,'Philip','Mitchel','07246133723',NULL,NULL,1,CURDATE(),1,CURDATE());
INSERT INTO person VALUES(NULL,'John','Miles','Travolta',3,'1953-07-12','07456133733','nightfever@middlesbro.ac.uk',4,'Jackie','Travolta','07116123789',NULL,NULL,1,CURDATE(),1,CURDATE());
INSERT INTO person VALUES(NULL,'Sarah','Shadrack','Travolta',3,'1973-03-10','07456663733','nightfever2@middlesbro.ac.uk',4,'John','Travolta','07456133733',NULL,NULL,1,CURDATE(),1,CURDATE());