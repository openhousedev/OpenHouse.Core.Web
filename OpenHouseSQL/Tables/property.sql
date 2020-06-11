SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS property;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `property` (
	`propertyId` INT NOT NULL AUTO_INCREMENT,
	`propertyClassId` INT NOT NULL,
	`propertyTypeId` INT,
	`propertyNum` INT NULL,
	`propertySubNum` VARCHAR(5),
	`address1` VARCHAR(500),
	`address2` VARCHAR(500),
	`address3` VARCHAR(500),
	`address4` VARCHAR(500),
	`postCode` VARCHAR(8),
	`demolitionDate` DATETIME,
	`creationDate` DATETIME,
	`livingRoomQty` INT,
	`singleBedroomQty` INT,
	`doubleBedroomQty` INT,
	`maxOccupants` INT,
	`updatedByUserID` VARCHAR(255) NOT NULL,
	`updatedDT` DATETIME NOT NULL,
	`createdByUserID` VARCHAR(255) NOT NULL,
	`createdDT` DATETIME NOT NULL,
	PRIMARY KEY(`propertyId`),
	FOREIGN KEY (`propertyClassId`) REFERENCES propertyclass(`propertyClassId`),
	FOREIGN KEY (`propertyTypeId`) REFERENCES propertyType(`propertyTypeId`)
)
COLLATE='utf8_general_ci'
ENGINE=InnoDB
;
SET @currDate = CURDATE();

	
	
INSERT INTO property VALUES(NULL,1,3,NULL,NULL,'Hardgate Road','Hill View','Sunderland', 'Tyne & Wear', 'SR2 9LG', NULL, CURDATE(), NULL, NULL, NULL, NULL,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,1,1,NULL,'1 Hardgate Road','Hill View','Sunderland', 'Tyne & Wear', 'SR2 9LG', NULL, CURDATE(), 1, 1, 1, 3,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,1,2,NULL,'2 Hardgate Road','Hill View','Sunderland', 'Tyne & Wear', 'SR2 9LG', NULL, CURDATE(), 1, 1, 2, 5,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,1,3,NULL,'3 Hardgate Road','Hill View','Sunderland', 'Tyne & Wear', 'SR2 9LG', NULL, CURDATE(), 1, 2, 1, 4,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,1,4,NULL,'4 Hardgate Road','Hill View','Sunderland', 'Tyne & Wear', 'SR2 9LG', NULL, CURDATE(), 1, 2, 1, 4,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,1,5,NULL,'5 Hardgate Road','Hill View','Sunderland', 'Tyne & Wear', 'SR2 9LG', NULL, CURDATE(), 1, 2, 1, 4,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,1,5,NULL,'6 Hardgate Road','Hill View','Sunderland', 'Tyne & Wear', 'SR2 9LG', NULL, CURDATE(), 1, 1, 2, 5,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,1,5,NULL,'7 Hardgate Road','Hill View','Sunderland', 'Tyne & Wear', 'SR2 9LG', NULL, CURDATE(), 1, 1, 1, 3,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,1,5,NULL,'8 Hardgate Road','Hill View','Sunderland', 'Tyne & Wear', 'SR2 9LG', NULL, CURDATE(), 1, 1, 1, 3,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());

INSERT INTO property VALUES(NULL,1,3,NULL,NULL,'Alice Street','Ashbrooke','Sunderland', 'Tyne & Wear', 'SR2 7AL', NULL, CURDATE(), NULL, NULL, NULL, NULL,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,1,1,NULL,'1 Alice Street','Ashbrooke','Sunderland', 'Tyne & Wear', 'SR2 7AL', NULL, CURDATE(), 1, 1, 1, 3,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,1,2,NULL,'2 Alice Street','Ashbrooke','Sunderland', 'Tyne & Wear', 'SR2 7AL', NULL, CURDATE(), 1, 1, 1, 3,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,1,3,NULL,'3 Alice Street','Ashbrooke','Sunderland', 'Tyne & Wear', 'SR2 7AL', NULL, CURDATE(), 1, 1, 2, 5,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,1,4,NULL,'4 Alice Street','Ashbrooke','Sunderland', 'Tyne & Wear', 'SR2 7AL', NULL, CURDATE(), 1, 1, 1, 3,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,1,5,NULL,'5 Alice Street','Ashbrooke','Sunderland', 'Tyne & Wear', 'SR2 7AL', NULL, CURDATE(), 1, 1, 1, 3,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,1,5,NULL,'6 Alice Street','Ashbrooke','Sunderland', 'Tyne & Wear', 'SR2 7AL', NULL, CURDATE(), 1, 2, 1, 4,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,1,5,NULL,'7 Alice Street','Ashbrooke','Sunderland', 'Tyne & Wear', 'SR2 7AL', NULL, CURDATE(), 1, 1, 1, 3,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,1,5,NULL,'8 Alice Street','Ashbrooke','Sunderland', 'Tyne & Wear', 'SR2 7AL', NULL, CURDATE(), 1, 1, 2, 5,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());

INSERT INTO property VALUES(NULL,2,3,NULL,NULL,'Astral Tower','City Centre','Sunderland', 'Tyne & Wear', 'SR1 7LG', NULL, CURDATE(), NULL, NULL, NULL, NULL,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,6,1,NULL,'1 Astral Tower','City Centre','Sunderland', 'Tyne & Wear', 'SR1 7LG', NULL, CURDATE(), 1, 1, 1, 3,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,6,2,NULL,'2 Astral Tower','City Centre','Sunderland', 'Tyne & Wear', 'SR1 7LG', NULL, CURDATE(), 1, 1, 1, 3,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,6,3,NULL,'3 Astral Tower','City Centre','Sunderland', 'Tyne & Wear', 'SR1 7LG', NULL, CURDATE(), 1, 1, 2, 5,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,6,4,NULL,'4 Astral Tower','City Centre','Sunderland', 'Tyne & Wear', 'SR1 7LG', NULL, CURDATE(), 1, 1, 1, 3,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,6,5,NULL,'5 Astral Tower','City Centre','Sunderland', 'Tyne & Wear', 'SR1 7LG', NULL, CURDATE(), 1, 1, 1, 3,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,6,5,NULL,'6 Astral Tower','City Centre','Sunderland', 'Tyne & Wear', 'SR1 7LG', NULL, CURDATE(), 1, 2, 1, 4,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,6,5,NULL,'7 Astral Tower','City Centre','Sunderland', 'Tyne & Wear', 'SR1 7LG', NULL, CURDATE(), 1, 1, 1, 3,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,6,5,NULL,'8 Astral Tower','City Centre','Sunderland', 'Tyne & Wear', 'SR1 7LG', NULL, CURDATE(), 1, 1, 2, 5,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());

INSERT INTO property VALUES(NULL,1,8,NULL,NULL,'Abercorn Road','Farringdon','Sunderland', 'Tyne & Wear', 'SR3 3XR', NULL, CURDATE(), NULL, NULL, NULL, NULL,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,6,1,NULL,'1 Abercorn Road','Farringdon','Sunderland', 'Tyne & Wear', 'SR3 3XR', NULL, CURDATE(), 1, 1, 1, 3,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,6,2,NULL,'2 Abercorn Road','Farringdon','Sunderland', 'Tyne & Wear', 'SR3 3XR', NULL, CURDATE(), 1, 1, 1, 3,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,6,3,NULL,'3 Abercorn Road','Farringdon','Sunderland', 'Tyne & Wear', 'SR3 3XR', NULL, CURDATE(), 1, 1, 2, 5,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,6,4,NULL,'4 Abercorn Road','Farringdon','Sunderland', 'Tyne & Wear', 'SR3 3XR', NULL, CURDATE(), 1, 1, 1, 3,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,6,5,NULL,'5 Abercorn Road','Farringdon','Sunderland', 'Tyne & Wear', 'SR3 3XR', NULL, CURDATE(), 1, 1, 1, 3,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,6,5,NULL,'6 Abercorn Road','Farringdon','Sunderland', 'Tyne & Wear', 'SR3 3XR', NULL, CURDATE(), 1, 2, 1, 4,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,6,5,NULL,'7 Abercorn Road','Farringdon','Sunderland', 'Tyne & Wear', 'SR3 3XR', NULL, CURDATE(), 1, 1, 1, 3,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO property VALUES(NULL,3,6,5,NULL,'8 Abercorn Road','Farringdon','Sunderland', 'Tyne & Wear', 'SR3 3XR', NULL, CURDATE(), 1, 1, 2, 5,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());






