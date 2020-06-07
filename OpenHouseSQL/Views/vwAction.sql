DROP VIEW IF EXISTS `vwAction`;

CREATE VIEW `vwAction` AS
SELECT
	action.actionId, 
	action.actionTypeId, 
	actiontype.actionType, 
	action.tenancyId, 
	vwtenancy.contactAddress, 
	action.actionDueDate, 
	action.actionCompletedDate, 
	action.updatedByUserID, 
	action.updatedDT, 
	action.createdByUserID, 
	action.createdDT, 
	action.assignedUserId
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