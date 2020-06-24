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