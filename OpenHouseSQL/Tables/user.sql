DROP TABLE `property`;

CREATE TABLE `property` (
	`propertyId` INT NOT NULL AUTO_INCREMENT,
	`` VARCHAR(100) NOT NULL,
	PRIMARY KEY (`userId`)
)
COLLATE='utf8_general_ci'
;

INSERT INTO `user` VALUES (1,'admin'),
								  (2,'ross.ballantine'),
								  (3,'housing.user');
