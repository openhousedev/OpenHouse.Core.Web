SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS `action`;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `action` (
	`actionId` INT NOT NULL AUTO_INCREMENT,
	`actionTypeId` INT NOT NULL,
	`tenancyId` INT NOT NULL,
	`assignedUserId` VARCHAR(255) NOT NULL,
	`actionDueDate` DATETIME NOT NULL,
	`actionCompletedDate` DATETIME,
	`updatedByUserID` VARCHAR(255) NOT NULL,
	`updatedDT` DATETIME NOT NULL,
	`createdByUserID` VARCHAR(255) NOT NULL,
	`createdDT` DATETIME NOT NULL,
	PRIMARY KEY(`actionId`),
	FOREIGN KEY (`actionTypeId`) REFERENCES actionType(`actionTypeId`),
	FOREIGN KEY (`tenancyId`) REFERENCES tenancy(`tenancyId`)
)

COLLATE='utf8_general_ci'
ENGINE=InnoDB
;
SET @currDate = CURDATE();

INSERT INTO `action` VALUES(NULL,2,1,'611a361a-bce9-4783-b715-da82528a5988'vwaction,@currDate,NULL,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());

