SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS `action`;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `action` (
	`actionId` INT NOT NULL AUTO_INCREMENT,
	`actionTypeId` INT NOT NULL,
	`tenancyId` INT NOT NULL,
	`assignedUserId` INT NOT NULL,
	`actionDueDate` DATETIME NOT NULL,
	`actionCompletedDate` DATETIME,
	`updatedByUserID` INT NOT NULL,
	`updatedDT` DATETIME NOT NULL,
	`createdByUserID` INT NOT NULL,
	`createdDT` DATETIME NOT NULL,
	PRIMARY KEY(`actionId`),
	FOREIGN KEY (`actionTypeId`) REFERENCES actionType(`actionTypeId`),
	FOREIGN KEY (`tenancyId`) REFERENCES tenancy(`tenancyId`)
)

COLLATE='utf8_general_ci'
ENGINE=InnoDB
;
SET @currDate = CURDATE();

INSERT INTO `action` VALUES(NULL,2,1,1,@currDate,NULL,1,@currDate,1,@currdate);

