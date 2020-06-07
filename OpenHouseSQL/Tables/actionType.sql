SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS `actionType`;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `actionType` (
	`actionTypeId` INT NOT NULL AUTO_INCREMENT,
	`actionType` VARCHAR(100),
	PRIMARY KEY(`actionTypeId`)
)

COLLATE='utf8_general_ci'
ENGINE=InnoDB
;
SET @currDate = CURDATE();

INSERT INTO actionType VALUES(1,'Other');
INSERT INTO actionType VALUES(2, '6 Month Inspection');
INSERT INTO actionType VALUES(3, '12 Month Inspection');
INSERT INTO actionType VALUES(4, 'Wellbeing Visit');
INSERT INTO actionType VALUES(5, 'Arrears Action');
INSERT INTO actionType VALUES(6, 'Anti-social Behaviour Action');