/*------------------------------------------------------------------------------------*/
/* OpenHouse SQL v1.0 DB Configuration Script - Released under the Apache 2.0 License */
/*------------------------------------------------------------------------------------*/
/* 				For further documentation please visit the wiki						  */ 
/*			https://github.com/openhousedev/OpenHouse.Core.Web/wiki					  */
/*------------------------------------------------------------------------------------*/

-- Create ActionType

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

--Create Action

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

-- Create AlertType

SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS alertType;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `alertType` (
	`alertTypeId` INT NOT NULL,
	`alertType` VARCHAR(100),
	PRIMARY KEY(`alertTypeId`)
)

COLLATE='utf8_general_ci'
ENGINE=InnoDB
;

INSERT INTO `alertType` VALUES(1,'INFORMATION');
INSERT INTO `alertType` VALUES(2,'SAFETY');
INSERT INTO `alertType` VALUES(3,'DISABILITY');

-- Create Alert

SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS alert;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `alert` (
	`alertId` INT NOT NULL AUTO_INCREMENT,
	`alertTypeId` INT,
	`alertText` TEXT,
	`startDT` DATETIME,
	`endDT` DATETIME,
	`updatedByUserID` VARCHAR(255) NOT NULL,
	`updatedDT` DATETIME NOT NULL,
	`createdByUserID` VARCHAR(255) NOT NULL,
	`createdDT` DATETIME NOT NULL,
	PRIMARY KEY(`alertId`),
	FOREIGN KEY(`alertTypeId`) REFERENCES alertType(`alertTypeId`)
)

COLLATE='utf8_general_ci'
ENGINE=InnoDB
;


-- Create Title

SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS title;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `title` (
	`titleId` INT NOT NULL AUTO_INCREMENT,
	`title` VARCHAR(100),
	PRIMARY KEY(`titleId`)
)

COLLATE='utf8_general_ci'
ENGINE=InnoDB
;
SET @currDate = CURDATE();

INSERT INTO title VALUES(1,'Dr');
INSERT INTO title VALUES(2,'Miss');
INSERT INTO title VALUES(3,'Mr');
INSERT INTO title VALUES(4,'Mrs');
INSERT INTO title VALUES(5,'Ms');
INSERT INTO title VALUES(6,'Mx');
INSERT INTO title VALUES(7,'Prof');
INSERT INTO title VALUES(8,'Rev');

--Create Nationalities

SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS nationality;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `nationality` (
	`nationalityId` INT NOT NULL AUTO_INCREMENT,
	`nationality` VARCHAR(100),
	PRIMARY KEY(`nationalityId`)
)


COLLATE='utf8_general_ci'
ENGINE=InnoDB
;
SET @currDate = CURDATE();

INSERT INTO `nationality` 
VALUES (1,'Afghan'),
	(2,'Albanian'),
	(3,'Algerian'),
	(4,'American'),
	(5,'Andorran'),
	(6,'Angolan'),
	(7,'Antiguans'),
	(8,'Argentinean'),
	(9,'Armenian'),
	(10,'Australian'),
	(11,'Austrian'),
	(12,'Azerbaijani'),
	(13,'Bahamian'),
	(14,'Bahraini'),
	(15,'Bangladeshi'),
	(16,'Barbadian'),
	(17,'Barbudans'),
	(18,'Batswana'),
	(19,'Belarusian'),
	(20,'Belgian'),
	(21,'Belizean'),
	(22,'Beninese'),
	(23,'Bhutanese'),
	(24,'Bolivian'),
	(25,'Bosnian'),
	(26,'Brazilian'),
	(27,'British'),
	(28,'Bruneian'),
	(29,'Bulgarian'),
	(30,'Burkinabe'),
	(31,'Burmese'),
	(32,'Burundian'),
	(33,'Cambodian'),
	(34,'Cameroonian'),
	(35,'Canadian'),
	(36,'Cape Verdean'),
	(37,'Central African'),
	(38,'Chadian'),
	(39,'Chilean'),
	(40,'Chinese'),
	(41,'Colombian'),
	(42,'Comoran'),
	(43,'Congolese'),
	(44,'Congolese'),
	(45,'Costa Rican'),
	(46,'Croatian'),
	(47,'Cuban'),
	(48,'Cypriot'),
	(49,'Czech'),
	(50,'Danish'),
	(51,'Djibouti'),
	(52,'Dominican'),
	(53,'Dominican'),
	(54,'Dutch'),
	(55,'Dutchman'),
	(56,'Dutchwoman'),
	(57,'East Timorese'),
	(58,'Ecuadorean'),
	(59,'Egyptian'),
	(60,'Emirian'),
	(61,'Equatorial Guinean'),
	(62,'Eritrean'),
	(63,'Estonian'),
	(64,'Ethiopian'),
	(65,'Fijian'),
	(66,'Filipino'),
	(67,'Finnish'),
	(68,'French'),
	(69,'Gabonese'),
	(70,'Gambian'),
	(71,'Georgian'),
	(72,'German'),
	(73,'Ghanaian'),
	(74,'Greek'),
	(75,'Grenadian'),
	(76,'Guatemalan'),
	(77,'Guinea-Bissauan'),
	(78,'Guinean'),
	(79,'Guyanese'),
	(80,'Haitian'),
	(81,'Herzegovinian'),
	(82,'Honduran'),
	(83,'Hungarian'),
	(84,'I-Kiribati'),
	(85,'Icelander'),
	(86,'Indian'),
	(87,'Indonesian'),
	(88,'Iranian'),
	(89,'Iraqi'),
	(90,'Irish'),
	(91,'Irish'),
	(92,'Israeli'),
	(93,'Italian'),
	(94,'Ivorian'),
	(95,'Jamaican'),
	(96,'Japanese'),
	(97,'Jordanian'),
	(98,'Kazakhstani'),
	(99,'Kenyan'),
	(100,'Kittian and Nevisian'),
	(101,'Kuwaiti'),
	(102,'Kyrgyz'),
	(103,'Laotian'),
	(104,'Latvian'),
	(105,'Lebanese'),
	(106,'Liberian'),
	(107,'Libyan'),
	(108,'Liechtensteiner'),
	(109,'Lithuanian'),
	(110,'Luxembourger'),
	(111,'Macedonian'),
	(112,'Malagasy'),
	(113,'Malawian'),
	(114,'Malaysian'),
	(115,'Maldivan'),
	(116,'Malian'),
	(117,'Maltese'),
	(118,'Marshallese'),
	(119,'Mauritanian'),
	(120,'Mauritian'),
	(121,'Mexican'),
	(122,'Micronesian'),
	(123,'Moldovan'),
	(124,'Monacan'),
	(125,'Mongolian'),
	(126,'Moroccan'),
	(127,'Mosotho'),
	(128,'Motswana'),
	(129,'Mozambican'),
	(130,'Namibian'),
	(131,'Nauruan'),
	(132,'Nepalese'),
	(133,'Netherlander'),
	(134,'New Zealander'),
	(135,'Ni-Vanuatu'),
	(136,'Nicaraguan'),
	(137,'Nigerian'),
	(138,'Nigerien'),
	(139,'North Korean'),
	(140,'Northern Irish'),
	(141,'Norwegian'),
	(142,'Omani'),
	(143,'Pakistani'),
	(144,'Palauan'),
	(145,'Panamanian'),
	(146,'Papua New Guinean'),
	(147,'Paraguayan'),
	(148,'Peruvian'),
	(149,'Polish'),
	(150,'Portuguese'),
	(151,'Qatari'),
	(152,'Romanian'),
	(153,'Russian'),
	(154,'Rwandan'),
	(155,'Saint Lucian'),
	(156,'Salvadoran'),
	(157,'Samoan'),
	(158,'San Marinese'),
	(159,'Sao Tomean'),
	(160,'Saudi'),
	(161,'Scottish'),
	(162,'Senegalese'),
	(163,'Serbian'),
	(164,'Seychellois'),
	(165,'Sierra Leonean'),
	(166,'Singaporean'),
	(167,'Slovakian'),
	(168,'Slovenian'),
	(169,'Solomon Islander'),
	(170,'Somali'),
	(171,'South African'),
	(172,'South Korean'),
	(173,'Spanish'),
	(174,'Sri Lankan'),
	(175,'Sudanese'),
	(176,'Surinamer'),
	(177,'Swazi'),
	(178,'Swedish'),
	(179,'Swiss'),
	(180,'Syrian'),
	(181,'Taiwanese'),
	(182,'Tajik'),
	(183,'Tanzanian'),
	(184,'Thai'),
	(185,'Togolese'),
	(186,'Tongan'),
	(187,'Trinidadian or Tobagonian'),
	(188,'Tunisian'),
	(189,'Turkish'),
	(190,'Tuvaluan'),
	(191,'Ugandan'),
	(192,'Ukrainian'),
	(193,'Uruguayan'),
	(194,'Uzbekistani'),
	(195,'Venezuelan'),
	(196,'Vietnamese'),
	(197,'Welsh'),
	(198,'Yemenite'),
	(199,'Zambian'),
	(200,'Zimbabwean');

--Create Note

SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS note;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `note` (
	`noteId` INT NOT NULL AUTO_INCREMENT,
	`note` TEXT,
	`updatedByUserID` VARCHAR(255) NOT NULL,
	`updatedDT` DATETIME NOT NULL,
	`createdByUserID` VARCHAR(255) NOT NULL,
	`createdDT` DATETIME NOT NULL,aspnetuserclaims
	PRIMARY KEY(`noteId`)
)

COLLATE='utf8_general_ci'
ENGINE=InnoDB
;

-- Create payment source

SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS paymentSource;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `paymentSource` (
	paymentSourceId INT NOT NULL AUTO_INCREMENT,
	`source` VARCHAR(100),
	PRIMARY KEY(`paymentSourceId`)

)
COLLATE='utf8_general_ci'
ENGINE=InnoDB
;
SET @currDate = CURDATE();

INSERT INTO paymentSource VALUES(1,'Direct Debit');
INSERT INTO paymentSource VALUES(2,'PayPoint');
INSERT INTO paymentSource VALUES(3,'Cash');

--Create Payment

SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS payment;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `payment` (
	`paymentId` INT NOT NULL AUTO_INCREMENT,
	`propertyChargeId` INT NOT NULL,
	`tenancyId` INT NOT NULL,
	`paymentSourceId` INT NOT NULL,
	`amount` FLOAT,
	`paymentDT` DATETIME NOT NULL,
	`paymentProviderReference` VARCHAR(255),
	`updatedByUserID` VARCHAR(255) NOT NULL,
	`updatedDT` DATETIME NOT NULL,
	`createdByUserID` VARCHAR(255) NOT NULL,
	`createdDT` DATETIME NOT NULL,
	PRIMARY KEY(`paymentId`),
	FOREIGN KEY(`propertyChargeId`) REFERENCES propertyCharge(`propertyChargeId`),
	FOREIGN KEY (`tenancyId`) REFERENCES tenancy(`tenancyId`),
	FOREIGN KEY (`paymentSourceId`) REFERENCES paymentSource(`paymentSourceId`)
)
COLLATE='utf8_general_ci'
ENGINE=InnoDB
;
SET @currDate = CURDATE();

--Create Person

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
	`updatedByUserID` VARCHAR(255) NOT NULL,
	`updatedDT` DATETIME NOT NULL,
	`createdByUserID` VARCHAR(255) NOT NULL,
	`createdDT` DATETIME NOT NULL,
	PRIMARY KEY(`personId`),
	FOREIGN KEY (`titleId`) REFERENCES title(`titleId`),
	FOREIGN KEY (`nationalityId`) REFERENCES nationality(`nationalityId`)
)

COLLATE='utf8_general_ci'
ENGINE=InnoDB
;
SET @currDate = CURDATE();

-- Create PropertyClass

SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS propertyclass;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `propertyClass` (
	`propertyClassId` INT NOT NULL AUTO_INCREMENT,
	`propertyClass` VARCHAR(100) NULL DEFAULT NULL,
	PRIMARY KEY(`propertyClassId`) USING BTREE
)
COLLATE='utf8_general_ci'
ENGINE=InnoDB
;

INSERT INTO propertyClass VALUES(1,'Street');
INSERT INTO propertyClass VALUES(2,'Block');
INSERT INTO propertyClass VALUES(3,'House');
INSERT INTO propertyClass VALUES(4,'Garage');

--Create PropertyNote

SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS propertyNote;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `propertyNote` (
	`propertyNoteId` INT NOT NULL AUTO_INCREMENT,
	`noteId` INT NOT NULL,
	`propertyId` INT NOT NULL,
	PRIMARY KEY(`propertyNoteId`),
	FOREIGN KEY(`propertyId`) REFERENCES property(`propertyId`),
	FOREIGN KEY(`noteId`) REFERENCES note(`noteId`)
)

COLLATE='utf8_general_ci'
ENGINE=InnoDB
;

--Create PropertyType

SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS propertyType;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `propertyType` (
	`propertyTypeId` INT NOT NULL,
	`propertyType` VARCHAR(100) NULL DEFAULT NULL,
	PRIMARY KEY(`propertyTypeId`)
)
COLLATE='utf8_general_ci'
ENGINE=InnoDB
;

INSERT INTO propertyType VALUES(1,'Semi-Detached House');
INSERT INTO propertyType VALUES(2,'Detached');
INSERT INTO propertyType VALUES(3,'Street');
INSERT INTO propertyType VALUES(4,'Cottage');
INSERT INTO propertyType VALUES(5,'Bungalow');
INSERT INTO propertyType VALUES(6,'Appartment');
INSERT INTO propertyType VALUES(7,'Bedsit');
INSERT INTO propertyType VALUES(8,'High Rise');

-- Create Property

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

-- Create Relationship

SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS relationship;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `relationship` (
	`relationshipId` INT NOT NULL AUTO_INCREMENT,
	`relationship` VARCHAR(100),
	PRIMARY KEY(`relationshipId`)
)

COLLATE='utf8_general_ci'
ENGINE=InnoDB
;
SET @currDate = CURDATE();

INSERT INTO relationship VALUES(1,'None');
INSERT INTO relationship VALUES(2,'Wife');
INSERT INTO relationship VALUES(3,'Husband');
INSERT INTO relationship VALUES(4,'Partner');
INSERT INTO relationship VALUES(5,'Child');
INSERT INTO relationship VALUES(6,'Niece');
INSERT INTO relationship VALUES(7,'Nephew');
INSERT INTO relationship VALUES(8,'Brother');
INSERT INTO relationship VALUES(9,'Sister');
INSERT INTO relationship VALUES(10,'Parent');

-- Create RentAccount

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

-- Create PropertyCharge

SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS propertyCharge;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `propertyCharge` (
	`propertyChargeId` INT NOT NULL AUTO_INCREMENT,
	`propertyId` INT NOT NULL,
	`rentAccountId` INT NOT NULL,
	`charge` FLOAT,
	`startDT` DATETIME NOT NULL,
	`endDT` DATETIME NULL,
	`updatedByUserID` VARCHAR(255) NOT NULL,
	`updatedDT` DATETIME NOT NULL,
	`createdByUserID` VARCHAR(255) NOT NULL,
	`createdDT` DATETIME NOT NULL,
	PRIMARY KEY(`propertyChargeId`),
	FOREIGN KEY(`propertyId`) REFERENCES property(`propertyId`),
	FOREIGN KEY (`rentAccountId`) REFERENCES rentAccount(`rentAccountId`)
)
COLLATE='utf8_general_ci'
ENGINE=InnoDB
;
SET @currDate = CURDATE();

-- Create TenureType

SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS tenuretype;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `tenureType` (
	`tenureTypeId` INT NOT NULL AUTO_INCREMENT,
	`tenureType` VARCHAR(100) NULL DEFAULT NULL,
	PRIMARY KEY(`tenureTypeId`)
)
COLLATE='utf8_general_ci'
ENGINE=InnoDB
;

INSERT INTO tenureType VALUES(1,'Assured');
INSERT INTO tenureType VALUES(2,'Homeless');
INSERT INTO tenureType VALUES(3,'Leased');
INSERT INTO tenureType VALUES(4,'Private Garage');
INSERT INTO tenureType VALUES(5,'Rent to Buy');

-- Create TenancyTerminationReason

SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS tenancyTerminationReason;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `tenancyTerminationReason` (
	`tenancyTerminationReasonId` INT NOT NULL AUTO_INCREMENT,
	`terminationReason` VARCHAR(100) NULL DEFAULT NULL,
	PRIMARY KEY(`tenancyTerminationReasonId`)
)
COLLATE='utf8_general_ci'
ENGINE=InnoDB
;

INSERT INTO tenancyTerminationReason VALUES(1,'Relocation');
INSERT INTO tenancyTerminationReason VALUES(2,'Cost');
INSERT INTO tenancyTerminationReason VALUES(3,'Deceased');
INSERT INTO tenancyTerminationReason VALUES(4,'Evicted');
INSERT INTO tenancyTerminationReason VALUES(5,'Property too large');
INSERT INTO tenancyTerminationReason VALUES(6,'Property too small');

-- Create Tenancy

SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS tenancy;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `tenancy` (
	`tenancyId` INT NOT NULL AUTO_INCREMENT,
	`propertyId` INT,
	`leadTenantPersonId` INT NOT NULL,
	`jointTenantPersonId` INT NULL,
	`tenureTypeId` INT NOT NULL,
	`startDate` datetime,
	`terminationDate` datetime,
	`terminationReasonId` INT NULL,
	`updatedByUserID` VARCHAR(255) NOT NULL,
	`updatedDT` DATETIME NOT NULL,
	`createdByUserID` VARCHAR(255) NOT NULL,
	`createdDT` DATETIME NOT NULL,
	PRIMARY KEY(`tenancyId`),
	FOREIGN KEY (`tenureTypeId`) REFERENCES tenureType(`tenureTypeId`),
	FOREIGN KEY (`leadTenantPersonId`) REFERENCES person(`personId`),
	FOREIGN KEY (`jointTenantPersonId`) REFERENCES person(`personId`),
	FOREIGN KEY (`terminationReasonId`) REFERENCES tenancyterminationreason(`tenancyTerminationReasonId`)
)

COLLATE='utf8_general_ci'
ENGINE=InnoDB
;
SET @currDate = CURDATE();

-- Create Tenancy Alert

SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS tenancyAlert;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `tenancyAlert` (
	`tenancyAlertId` INT NOT NULL AUTO_INCREMENT,
	`tenancyId` INT NOT NULL,
	`alertId` INT NOT NULL,
	PRIMARY KEY(`tenancyAlertId`),
	FOREIGN KEY(`tenancyId`) REFERENCES tenancy(`tenancyId`),
	FOREIGN KEY(`alertId`) REFERENCES alert(`alertId`)
)

COLLATE='utf8_general_ci'
ENGINE=InnoDB
;


-- Create TenancyHousehold

SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS tenancyHousehold;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `tenancyHousehold` (
	`tenancyHouseholdId` INT NOT NULL AUTO_INCREMENT,
	`tenancyId` INT NOT NULL,
	`personId` INT NOT NULL,
	`leadTenantRelationshipId` INT NULL,
	`jointTenantRelationshipId` INT NULL,
	`updatedByUserID` VARCHAR(255) NOT NULL,
	`updatedDT` DATETIME NOT NULL,
	`createdByUserID` VARCHAR(255) NOT NULL,
	`createdDT` DATETIME NOT NULL,
	PRIMARY KEY(`tenancyHouseholdId`),
	FOREIGN KEY(`tenancyId`) REFERENCES tenancy(`tenancyId`),
	FOREIGN KEY(`personId`) REFERENCES person(`personId`),
	FOREIGN KEY(`leadTenantRelationshipId`) REFERENCES relationship(`relationshipId`),
	FOREIGN KEY(`jointTenantRelationshipId`) REFERENCES relationship(`relationshipId`)
)

COLLATE='utf8_general_ci'
ENGINE=InnoDB
;
SET @currDate = CURDATE();

INSERT INTO tenancyHousehold VALUES(NULL,2,4,5,5,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());
INSERT INTO tenancyHousehold VALUES(NULL,3,6,2,NULL,'611a361a-bce9-4783-b715-da82528a5988',CURDATE(),'611a361a-bce9-4783-b715-da82528a5988',CURDATE());

-- Create TenancyNote

SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS tenancyNote;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `tenancyNote` (
	`tenancyNoteId` INT NOT NULL AUTO_INCREMENT,
	`noteId` INT NOT NULL,
	`tenancyId` INT NOT NULL,
	PRIMARY KEY(`tenancyNoteId`),
	FOREIGN KEY(`tenancyId`) REFERENCES tenancy(`tenancyId`),
	FOREIGN KEY(`noteId`) REFERENCES note(`noteId`)
)

COLLATE='utf8_general_ci'
ENGINE=InnoDB
;

-- Create RentLedger

SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS rentLedger;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `rentLedger` (
	`rentLedgerId` INT NOT NULL AUTO_INCREMENT,
	`tenancyId` INT NOT NULL,
	`propertyChargeId` INT NOT NULL,
	`periodStartDT` DATETIME NOT NULL,
	`periodEndDT` DATETIME NOT NULL,
	`paymentId` INT NULL,
	`updatedDT` DATETIME NOT NULL,
	`createdDT` DATETIME NOT NULL,
	PRIMARY KEY(`rentLedgerId`),
	FOREIGN KEY (`tenancyId`) REFERENCES tenancy(`tenancyId`),
	FOREIGN KEY (`paymentId`) REFERENCES payment(`paymentId`)
)

COLLATE='utf8_general_ci'
ENGINE=InnoDB
;
SET @currDate = CURDATE();

-- Create evtPopulateRentLedger

CREATE DEFINER=`root`@`localhost` EVENT `evtPopulateRentLedger`
	ON SCHEDULE
		EVERY 1 MINUTE STARTS '2020-06-21 12:01:13'
	ON COMPLETION NOT PRESERVE
	ENABLE
	COMMENT ''
	DO BEGIN

INSERT INTO 
		rentledger (tenancyId, propertyChargeId, periodStartDT, periodEndDT, updatedDT, createdDT) /*Create first rent ledger record for 7 days after tenancy start date*/
			/* Get tenancies created on current date*/
	WITH cteDailyTenancies (tenancyId, propertyId, startDate) AS (
		SELECT 
			  tenancyId
			, propertyID
			, tenancy.startDate
		FROM 
			tenancy
		WHERE 
			 tenancy.startDate = CURDATE()
	)
	SELECT 
		  tenancyId
		, propertyChargeId
		, dt.startDate
		, DATE_ADD(startDT,INTERVAL 7 DAY)
		, CURDATE()
		, CURDATE()
	FROM 
		propertycharge pc
	INNER JOIN
		cteDailyTenancies dt
	ON
		pc.propertyId = dt.propertyId
	WHERE 
			pc.startDT < CURDATE()
		AND
			(pc.endDT IS NULL OR pc.endDT >= CURDATE());

	/* Create next rent ledger record for next weekly rent accounting period */
	INSERT INTO 
		rentledger (tenancyId, propertyChargeId, periodStartDT, periodEndDT, updatedDT, createdDT)
				/* Get all rent ledger records which end on current date */
	WITH cteWeeklyTenancies (tenancyId, rentLedgerId, propertyChargeId, charge, periodStartDT, periodEndDT, nextPeriodEndDate, nextPeriodStartDate) AS (
		SELECT 
			  t.tenancyId
			, MAX(rentLedgerId)
			, pc.propertyChargeId
			, pc.charge
			, periodStartDT
			, periodEndDT 
			, CASE 
					WHEN t.terminationDate IS NULL OR t.terminationDate > DATE_ADD(rl.periodEndDT, INTERVAL 7 DAY) THEN
						DATE_ADD(periodEndDT, INTERVAL 7 DAY)
					ELSE
						t.terminationDate
					END 
						AS nextPeriodEndDate
			,	DATE_ADD(periodEndDT, INTERVAL 1 DAY) AS nextPeriodStartDate
		FROM 
			rentledger rl
		INNER JOIN
			tenancy t
		ON
			rl.tenancyId = t.tenancyId
		INNER JOIN
			propertycharge pc
		ON
			rl.propertyChargeId = pc.propertyChargeId
		WHERE 
			CURDATE() = rl.periodEndDT
		GROUP BY
			tenancyId
	)
	SELECT
		 tenancyId
	  , propertyChargeId
	  , nextPeriodStartDate
	  , nextPeriodEndDate
	  , CURDATE()
	  , CURDATE()
	FROM
		cteWeeklyTenancies;
		
END

-- Create vwAction

DROP VIEW IF EXISTS `vwAction`;

CREATE VIEW `vwAction` AS
SELECT
	action.actionId, 
	action.actionTypeId, 
	actiontype.actionType, 
	action.tenancyId, 
	vwtenancy.propertyId,
	vwtenancy.contactAddress, 
	action.actionDueDate, 
	action.actionCompletedDate, 
	action.updatedByUserID, 
	action.updatedDT, 
	action.createdByUserID, 
	action.createdDT, 
	action.assignedUserId,
	vwuser.UserName AS assignedUsername
FROM
	action
	INNER JOIN
	actiontype
	ON 
		action.actionTypeId = actiontype.actionTypeId
	INNER JOIN
	vwtenancy
	ON 
		action.tenancyId = vwtenancy.tenancyId
	INNER JOIN
	vwuser
	ON
		action.assignedUserId = vwUser.Id

-- Create vwAlert

	DROP VIEW IF EXISTS `vwAlert`;

	CREATE VIEW `vwAlert` AS
	SELECT DISTINCT
		 ta.tenancyAlertId
	  , ta.tenancyId
	  , a.alertId
	  , a.alertTypeId
	  , alt.alerttype
	  , a.alertText
	  , a.startDT
	  , a.endDT
	  , a.updatedByUserID
	  , uu.UserName AS updateByUsername
	  , updatedDT
	  , createdByUserID
	  , cu.UserName AS createdByUsername
	  , createdDT
	FROM 
		alert a
	INNER JOIN
		alerttype alt
	ON
		a.alertTypeId = alt.alertTypeId
	INNER JOIN
		tenancyalert ta
	ON
		a.alertId = ta.alertId
	INNER JOIN
		vwuser uu
	ON
		a.updatedByUserId = uu.Id
	INNER JOIN
		vwuser cu
	ON
		a.createdByUserId = cu.Id
		
-- Create vwPerson

DROP VIEW IF EXISTS `vwPerson`;

CREATE VIEW `vwPerson` AS
SELECT
	person.personId, 
	person.firstName, 
	person.middleName, 
	person.surname, 
	CONCAT(person.firstName,' ', person.surname) AS fullName,
	person.titleId, 
	title.title, 
	person.dateOfBirth, 
	person.telephone, 
	person.email, 
	person.nationalityId, 
	nationality.nationality, 
	person.nextOfKinFrstName, 
	person.nextOfKinSurname, 
	person.nextOfKinTelephone, 
	person.updatedByUserID, 
	person.updatedDT, 
	person.createdByUserID, 
	person.createdDT
FROM
	person
	INNER JOIN
	title
	ON 
		person.titleId = title.titleId
	INNER JOIN
	nationality
	ON
		person.nationalityId = nationality.nationalityIdaspnetusers

-- Create vwProperty

DROP VIEW IF EXISTS `vwProperty`;

CREATE VIEW `vwProperty` AS
WITH cteActiveTenancy AS (
SELECT DISTINCT 
		 t.tenancyId
		,t.propertyId
		,t.leadTenantPersonId
FROM
		 openhouse.tenancy t
WHERE
		 t.terminationDate IS NULL 
		 OR 
		 t.terminationDate > CURDATE()
)
SELECT DISTINCT 
	  p.propertyId
	, p.propertyClassId
   , pc.propertyClass
	, p.propertyTypeId
   , pt.propertyType
	, p.propertyNum
	, p.propertySubNum
	, p.address1
	, p.address2
	, p.address3
	, p.address4
	, p.postCode
	, CONCAT(p.address1,' ', p.address2,' ', p.address3, ' ', p.address4, ' ', p.postCode) AS contactAddress
	, p.demolitionDate
	, p.creationDate
	, p.livingRoomQty
	, p.singleBedroomQty
	, p.doubleBedroomQty
	, p.maxOccupants
	, t.tenancyId
	, p.updatedByUserID
	, p.updatedDT
	, p.createdByUserID
	, p.createdDT
FROM 
	openhouse.property p
INNER JOIN
	openhouse.propertyClass pc
ON
	p.propertyClassId = pc.propertyClassId
INNER JOIN
	openhouse.propertyType pt
ON
	p.propertyTypeId = pt.propertyTypeId
LEFT JOIN
	cteActiveTenancy t
ON
	t.propertyId = p.propertyId


-- Create vwRentLedger

DROP VIEW IF EXISTS `vwRentLedger`;

CREATE VIEW `vwRentLedger` AS
SELECT DISTINCT
	  rl.rentLedgerId
	, rl.tenancyId
	, rl.periodStartDT
	, rl.periodEndDT
	, pc.propertyChargeId
	, pc.charge
	, ra.rentAccountId
	, ra.rentAccount
	, p.paymentId
	, p.amount
	, p.paymentSourceId
	, p.paymentProviderReference
	, p.paymentDT
FROM 
	rentledger rl
INNER JOIN
	propertycharge pc
ON
	rl.propertyChargeId = pc.propertyChargeId
INNER JOIN
	rentaccount ra
ON
	pc.rentAccountId = ra.rentAccountId
LEFT OUTER JOIN
	payment p
ON
	rl.paymentId = p.paymentId;

-- Create vwTenancy

DROP VIEW IF EXISTS `vwTenancy`;

CREATE VIEW `vwTenancy` AS

SELECT DISTINCT
	tenancy.tenancyId, 
	tenancy.propertyId, 
	vwproperty.contactAddress, 
	tenancy.leadTenantPersonId, 
	CONCAT(personLead.firstName,' ', personLead.surname) as leadTenant, 
	tenancy.jointTenantPersonId, 
	CONCAT(personJoint.firstName,' ', personJoint.surname) as jointTenant, 
	tenancy.tenureTypeId, 
	tenuretype.tenureType, 
	tenancy.startDate, 
	tenancy.terminationDate, 
	tenancy.terminationReasonId, 
	tenancyterminationreason.terminationReason, 
	tenancy.updatedByUserID, 
	tenancy.updatedDT, 
	tenancy.createdByUserID, 
	tenancy.createdDT
FROM
	tenancy
	INNER JOIN
	person personLead
	ON 
		tenancy.leadTenantPersonId = personLead.personId
	LEFT JOIN
	person personJoint
	ON 
		tenancy.jointTenantPersonId = personJoint.personId
	INNER JOIN
	tenuretype
	ON 
		tenancy.tenureTypeId = tenuretype.tenureTypeId
	LEFT JOIN
	tenancyterminationreason
	ON 
		tenancy.terminationReasonId = tenancyterminationreason.tenancyTerminationReasonId
	INNER JOIN
	vwproperty
	ON 
		tenancy.propertyId = vwproperty.propertyId

-- Create vwTenancyHousehold

DROP VIEW IF EXISTS `vwTenancyHouseHold`;

CREATE VIEW `vwTenancyHousehold` AS

WITH cteLeadTenanct AS
SELECT DISTINCT
	0,
	tenancyhousehold.tenancyId, 
	tenancyhousehold.personId, 
	title.title, 
	person.firstName, 
	person.middleName, 
	person.surname, 
	CONCAT(person.firstName, ' ', person.surname) as fullName,
	person.dateOfBirth, 
	person.telephone, 
	person.email, 
	person.nationalityId, 
	nationality.nationality, 
	tenancyhousehold.leadTenantRelationshipId, 
	relationshipLead.relationship as relationshipToLeadTenant, 
	tenancyhousehold.jointTenantRelationshipId, 
	relationshipJoint.relationship as relationshipToJointTenant
FROM
	tenancy
	INNER JOIN
	person
	ON 
		tenancyhousehold.personId = person.personId
	INNER JOIN
	title
	ON 
		person.titleId = title.titleId
	LEFT JOIN
	nationality
	ON 
		person.nationalityId = nationality.nationalityId
	LEFT JOIN
	relationship relationshipLead
	ON 
		tenancyhousehold.jointTenantRelationshipId = relationshipLead.relationshipId
	LEFT JOIN
	relationship relationshipJoint
	ON 
		tenancyhousehold.leadTenantRelationshipId = relationshipJoint.relationshipId
		
SELECT
	tenancyhousehold.tenancyHouseholdId,
	tenancyhousehold.tenancyId, 
	tenancyhousehold.personId, 
	title.title, 
	person.firstName, 
	person.middleName, 
	person.surname, 
	CONCAT(person.firstName, ' ', person.surname) as fullName,
	person.dateOfBirth, 
	person.telephone, 
	person.email, 
	person.nationalityId, 
	nationality.nationality, 
	tenancyhousehold.leadTenantRelationshipId, 
	relationshipLead.relationship as relationshipToLeadTenant, 
	tenancyhousehold.jointTenantRelationshipId, 
	relationshipJoint.relationship as relationshipToJointTenant
FROM
	tenancyhousehold
	INNER JOIN
	person
	ON 
		tenancyhousehold.personId = person.personId
	INNER JOIN
	title
	ON 
		person.titleId = title.titleId
	LEFT JOIN
	nationality
	ON 
		person.nationalityId = nationality.nationalityId
	LEFT JOIN
	relationship relationshipLead
	ON 
		tenancyhousehold.jointTenantRelationshipId = relationshipLead.relationshipId
	LEFT JOIN
	relationship relationshipJoint
	ON 
		tenancyhousehold.leadTenantRelationshipId = relationshipJoint.relationshipId

-- Create vwUser

DROP VIEW IF EXISTS `vwUser`;

CREATE VIEW `vwUser` AS
SELECT
	  Id
	 ,UserName
	 ,Email
FROM
	openhouse_auth.aspnetusers