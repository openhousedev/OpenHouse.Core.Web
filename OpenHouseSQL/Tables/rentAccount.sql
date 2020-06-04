SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS rentAccount;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `rentAccount` (
	`rentAccountId` INT NOT NULL AUTO_INCREMENT,
	`rentAccount` VARCHAR(100),
	PRIMARY KEY(`rentAccountId`)
)

COLLATE='utf8_general_ci'
ENGINE=InnoDB
;
SET @currDate = CURDATE();

INSERT INTO rentAccount VALUES(1,'Rent');
INSERT INTO rentAccount VALUES(2,'Arrears');
INSERT INTO rentAccount VALUES(3,'Water Charges');
INSERT INTO rentAccount VALUES(4,'Garage');

