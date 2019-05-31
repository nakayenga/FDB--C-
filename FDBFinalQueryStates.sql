USE BHHCFinance

----------------------------------------------------------------------Variables--------------------------------------------------------------------------------------------------


--DECLARE @RUNDATE						DATE

--SET @RUNDATE							= '2019-03-31'

--------------------------------------------------------------------AccYr_DAC_ASL------------------------------------------------------------------------------------------------

if object_id('tempdb..#AccyrDACASLTable') is not null drop table #AccyrDACASLTable

SELECT
	RUN_DATE,
	COMPANY_CODE,
	ACCOUNT_NUMBER,
	IC,
	SG.LOB,
	REICO,
	CASE WHEN RI = 1 THEN 'D'
		 WHEN RI = 2 THEN 'A'
		 WHEN RI = 3 THEN 'C'
		 ELSE 'D' END AS TYPE_DAC,
	SEGMT,
	CASE WHEN ASLL.ASL = 17.1 AND REICO = 'KBS            ' THEN 17.2
		 WHEN ASLL.ASL = 17.1 AND REICO = 'KSBNKR         ' THEN 17.2
		 ELSE ASLL.ASL END AS AS_LINE,
	STATE,
	CASE WHEN WRIT_PREM IS NOT NULL THEN YEAR(RUN_DATE)
		 WHEN COMM_PD IS NOT NULL THEN YEAR(RUN_DATE)
		 WHEN COMM_UNPD IS NOT NULL THEN YEAR(RUN_DATE)
		 WHEN UE_PREM IS NOT NULL THEN YEAR(RUN_DATE)
		 WHEN LOSS_PD IS NOT NULL THEN ACCYR
		 WHEN ALAE_PD IS NOT NULL THEN ACCYR
		 WHEN ULAE_PD IS NOT NULL THEN ACCYR
		 WHEN SALV_SUB_L IS NOT NULL THEN ACCYR
		 WHEN SALV_SUB_E IS NOT NULL THEN ACCYR
		 WHEN LOSS_RES IS NOT NULL AND ACCYR <> 'PRIOR TO 1990  ' THEN ACCYR
		 WHEN LOSS_RES IS NOT NULL AND ACCYR = 'PRIOR TO 1990  ' THEN 1989
		 WHEN ALAE_RES IS NOT NULL AND ACCYR <> 'PRIOR TO 1990  ' THEN ACCYR
		 WHEN ALAE_RES IS NOT NULL AND ACCYR = 'PRIOR TO 1990  ' THEN 1989
		 WHEN LOSS_IBNR IS NOT NULL THEN ACCYR
		 WHEN ALAE_IBNR IS NOT NULL THEN ACCYR
		 WHEN ULAE_IBNR IS NOT NULL THEN ACCYR
		 ELSE YEAR(RUN_DATE) END AS ACCYR,
	WRIT_PREM,
	COMM_PD,
	LOSS_PD,
	ALAE_PD,
	ULAE_PD,
	SALV_SUB_L,
	SALV_SUB_E,
	COMM_UNPD,
	UE_PREM,
	LOSS_RES,
	ALAE_RES,
	LOSS_IBNR,
	ALAE_IBNR,
	ULAE_IBNR

INTO #AccyrDACASLTable

FROM fdb.SunGard SG

LEFT JOIN fdb.ASLLookup ASLL
ON SG.LOB = ASLL.LOB

------------------------------------------------------------To_From_Segment_UnderSegment_ReinsCode------------------------------------------------------------------------------

if object_id('tempdb..#ToFromCoUnderTable') is not null drop table #ToFromCoUnderTable

SELECT
	RUN_DATE,
	ADAT.COMPANY_CODE,
	ADAT.ACCOUNT_NUMBER,
	ADAT.IC,
	ADAT.LOB,
	ADAT.REICO,
	ADAT.TYPE_DAC,
	SEGMT,
	AS_LINE,
	ADAT.STATE,
	COALESCE(FCLB.FROM_CO, FCLR.FROM_CO, FCLI.FROM_CO, '     ') AS FROM_CO,
	COALESCE(CASE WHEN ADAT.TYPE_DAC = 'C' AND ADAT.REICO = 'CDI100         ' AND ACCYR > 1992 THEN 'RFC  '
				  WHEN ADAT.TYPE_DAC = 'C' AND ADAT.REICO = 'CDI100         ' AND ACCYR <= 1992 THEN 'NICO '
				  WHEN ADAT.REICO IS NOT NULL THEN TCLR.TO_CO
				  WHEN ADAT.REICO IS NULL THEN TCLI.TO_CO
				  END,
			'     ') AS TO_CO,
	COALESCE(CASE WHEN ADAT.ACCOUNT_NUMBER = '3011200' AND ADAT.REICO = 'AMRE4MXS2M     ' AND ADAT.STATE = 'CA' THEN 'CA-WC   '
				  WHEN ADAT.ACCOUNT_NUMBER = '3011200' AND ADAT.REICO = 'AMRE4MXS2M     ' AND ADAT.STATE <> 'CA' THEN 'AOS-WC  '
				  WHEN ADAT.ACCOUNT_NUMBER = '4011020' AND ADAT.SEGMT = 'PC             ' THEN 'RETAIL  '
				  WHEN ADAT.ACCOUNT_NUMBER = '4021143' AND ADAT.TYPE_DAC = 'D' THEN 'RETAIL  '
				  WHEN ADAT.ACCOUNT_NUMBER = '5971000' AND SEGMT = 'PC             ' THEN 'RETAIL  '
				  WHEN ADAT.ACCOUNT_NUMBER = '5971000' AND SEGMT = 'WC-CA          ' AND ADAT.REICO = 'CP             ' THEN 'CP      '
				  WHEN ADAT.ACCOUNT_NUMBER = '5971000' AND SEGMT = 'WC-CA          ' AND ADAT.REICO = 'FSIM           ' THEN 'FSIM    '
				  WHEN ADAT.ACCOUNT_NUMBER = '5971000' AND SEGMT = 'WC-CA          ' THEN 'CA-WC   '
				  WHEN ADAT.ACCOUNT_NUMBER = '5971000' AND SEGMT = 'WC-AOS         ' THEN 'AOS-WC  ' END,
			 SLR.SEGMENT, SLC.SEGMENT, SLA.SEGMENT, SL.SEGMENT) AS SEGMENT,
	CASE WHEN ADAT.COMPANY_CODE = 'RFC  ' AND ADAT.REICO = 'NICO4MXS2M' AND ADAT.STATE = 'CA' AND ACCYR < 2014 THEN 'BHHCBHRG'
		 WHEN ADAT.COMPANY_CODE = 'RFC  ' AND ADAT.REICO = 'NICO4MXS2M' AND (ADAT.STATE <> 'CA' OR ACCYR >= 2014) THEN 'BHHCOTHR'
		 WHEN ADAT.COMPANY_CODE = 'RFC  ' AND ADAT.REICO = 'NICO5MXS10M' AND ADAT.STATE = 'CA' AND ACCYR < 2014 THEN 'BHHCBHRG'
		 WHEN ADAT.COMPANY_CODE = 'RFC  ' AND ADAT.REICO = 'NICO5MXS10M' AND (ADAT.STATE <> 'CA' OR ACCYR >= 2014) THEN 'BHHCOTHR'
		 ELSE COALESCE(USLRC.UNDER_SEG, USLIC.UNDER_SEG, USLR.UNDER_SEG, USLI.UNDER_SEG,
			  CASE WHEN ADAT.TYPE_DAC = 'D' THEN 'BHHCCORE' END)
		 END AS UNDER_SEG,
	ACCYR,
	COALESCE(CASE WHEN ADAT.REICO = 'CDI100' AND ACCYR > 1992 THEN '9405'
				  WHEN ADAT.REICO = 'CDI100' AND ACCYR <= 1992 THEN '9406' 
				  WHEN ADAT.ACCOUNT_NUMBER IN ('3024020', '3018210') THEN '8949' END,
			RCLC.REINS_CODE, RCLN.REINS_CODE, RCLR.REINS_CODE, RCLI.REINS_CODE,'0000') AS REINS_CODE,
	ADAT.WRIT_PREM,
	ADAT.COMM_PD,
	COMM_UNPD,
	UE_PREM,
	LOSS_PD,
	ALAE_PD,
	ULAE_PD,
	SALV_SUB_L,
	SALV_SUB_E,
	LOSS_RES,
	ALAE_RES,
	LOSS_IBNR,
	ALAE_IBNR,
	ULAE_IBNR

INTO #ToFromCoUnderTable

FROM #AccyrDACASLTable ADAT

LEFT JOIN fdb.To_CoLookup TCLR
ON ADAT.TYPE_DAC = TCLR.DAC
AND ADAT.COMPANY_CODE = TCLR.COMPANY
AND ADAT.REICO = TCLR.REICO

LEFT JOIN fdb.To_CoLookup TCLI
ON ADAT.TYPE_DAC = TCLI.DAC
AND ADAT.COMPANY_CODE = TCLI.COMPANY
AND ADAT.IC = TCLI.IC

LEFT JOIN fdb.From_CoLookup FCLB
ON ADAT.TYPE_DAC = FCLB.DAC
AND ADAT.COMPANY_CODE = FCLB.COMPANY
AND ADAT.REICO = FCLB.REICO
AND ADAT.IC = FCLB.IC
AND FCLB.NOTES = 'BOTH'

LEFT JOIN fdb.From_CoLookup FCLR
ON ADAT.TYPE_DAC = FCLR.DAC
AND ADAT.COMPANY_CODE = FCLR.COMPANY
AND ADAT.REICO = FCLR.REICO
AND FCLR.NOTES = 'REICO'

LEFT JOIN fdb.From_CoLookup FCLI
ON ADAT.TYPE_DAC = FCLI.DAC
AND ADAT.COMPANY_CODE = FCLI.COMPANY
AND ADAT.IC = FCLI.IC
AND FCLI.NOTES = 'IC'

LEFT JOIN fdb.Under_SegLookup USLR
ON ADAT.TYPE_DAC = USLR.DAC
AND ADAT.REICO = USLR.REICO
AND USLR.NOTES = 'REICO'

LEFT JOIN fdb.Under_SegLookup USLRC
ON ADAT.TYPE_DAC = USLRC.DAC
AND ADAT.REICO = USLRC.REICO
AND ADAT.COMPANY_CODE = USLRC.COMPANY
AND USLRC.NOTES = 'RCOMPANY'

LEFT JOIN fdb.Under_SegLookup USLI
ON ADAT.TYPE_DAC = USLI.DAC
AND ADAT.IC = USLI.IC
AND USLI.NOTES = 'IC'

LEFT JOIN fdb.Under_SegLookup USLIC
ON ADAT.TYPE_DAC = USLIC.DAC
AND ADAT.COMPANY_CODE = USLIC.COMPANY
AND ADAT.IC = USLIC.IC
AND USLIC.NOTES = 'ICOMPANY'

LEFT JOIN fdb.Reins_CodeLookup RCLC
ON ADAT.REICO = RCLC.REICO
AND ADAT.STATE = RCLC.STATE
AND ADAT.LOB = RCLC.LOB
AND RCLC.NOTES = 'WC-CA'

LEFT JOIN fdb.Reins_CodeLookup RCLN
ON ADAT.REICO = RCLN.REICO
AND RCLN.NOTES = 'NONWC-CA'

LEFT JOIN fdb.Reins_CodeLookup RCLR
ON ADAT.REICO = RCLR.REICO
AND RCLR.NOTES = 'REICO'

LEFT JOIN fdb.Reins_CodeLookup RCLI
ON ADAT.IC = RCLI.IC
AND RCLI.NOTES = 'IC'

LEFT JOIN fdb.SegmentLookup SLR
ON ADAT.ACCOUNT_NUMBER = SLR.Account_Number
AND ADAT.COMPANY_CODE = SLR.Company
AND ADAT.REICO = SLR.REICO
AND SLR.NOTES = 'REICO'

LEFT JOIN fdb.SegmentLookup SLC
ON ADAT.ACCOUNT_NUMBER = SLC.Account_Number
AND ADAT.COMPANY_CODE = SLC.Company
AND ADAT.STATE = SLC.STATE
AND SLC.NOTES = 'WC-CA'

LEFT JOIN fdb.SegmentLookup SLA
ON ADAT.ACCOUNT_NUMBER = SLA.Account_Number
AND ADAT.COMPANY_CODE = SLA.Company
AND SLA.NOTES = 'WC-AOS' 

LEFT JOIN fdb.SegmentLookup SL
ON ADAT.ACCOUNT_NUMBER = SL.Account_Number
AND ADAT.COMPANY_CODE = SL.Company
AND SL.NOTES = 'Account' 

---------------------------------------------------------------------Affiliate--------------------------------------------------------------------------------------------------

if object_id('tempdb..#AddAffiliateTable') is not null drop table #AddAffiliateTable

SELECT
	RUN_DATE,
	CASE WHEN TFUT.COMPANY_CODE = 'CCC  ' THEN 'BHHIC'
		 ELSE TFUT.COMPANY_CODE END AS COMPANY_CODE,
	ACCOUNT_NUMBER,
	TFUT.IC,
	LOB,
	TFUT.REICO,
	TFUT.TYPE_DAC,
	SEGMT,
	AS_LINE,
	STATE,
	FROM_CO,
	TO_CO,
	SEGMENT,
	CASE WHEN TFUT.TYPE_DAC = 'D' THEN 'N'
		 WHEN TO_CO = 'OS   ' THEN 'N'
		 WHEN FROM_CO = 'OS   ' THEN 'N'
		 WHEN TO_CO <> 'OS   ' THEN 'Y'
		 WHEN FROM_CO <> 'OS   ' THEN 'Y'
	END AS AFFILIATE,
	UNDER_SEG,
	ACCYR,
	REINS_CODE,
	TFUT.WRIT_PREM,
	TFUT.COMM_PD,
	COMM_UNPD,
	UE_PREM,
	LOSS_PD,
	ALAE_PD,
	ULAE_PD,
	SALV_SUB_L,
	SALV_SUB_E,
	LOSS_RES,
	ALAE_RES,
	LOSS_IBNR,
	ALAE_IBNR,
	ULAE_IBNR

INTO #AddAffiliateTable

FROM #ToFromCoUnderTable TFUT

------------------------------------------------------------------------State_FDB------------------------------------------------------------------------------------------------

SELECT
	RUN_DATE AS EFFECTIVE_DATE,
	'SUNG' AS ENTRY_CODE,
	CASE WHEN LEN(MONTH(RUN_DATE)) = 1 THEN '=' + '"0' + CAST(MONTH(RUN_DATE) AS CHAR(1)) + '"' 
		 ELSE '=' + '"' + CAST(MONTH(RUN_DATE) AS CHAR(2)) + '"' END AS MONTH,
	'=' + '"' + CAST(YEAR(RUN_DATE) AS CHAR(4)) + '"' AS YEAR,
	COMPANY_CODE AS COMPANY,
	FROM_CO,
	TO_CO,
	SEGMENT,
	UNDER_SEG,
	AFFILIATE,
	TYPE_DAC,
	'=' + '"' + CAST(ACCYR AS CHAR(4)) + '"' AS ACC_YEAR,
	'=' + '"' + REINS_CODE + '"' AS REINS_CODE,
	CL.COVERAGE,
	CASE WHEN LEN(AS_LINE) = 3 THEN '=' + '"0' +  CAST(AS_LINE AS CHAR(3)) + '"'
		 ELSE '=' + '"' +  CAST(AS_LINE AS CHAR(4)) + '"' END AS AS_LINE,
	COALESCE(PPCL.PP_COMMER,' ') AS PP_COMMER,
	'USD' AS CURRENCY,
	COALESCE(STATE, '  ') AS STATES,
	CAST(COALESCE(SUM(WRIT_PREM) * -1, 0) AS DECIMAL(18,2)) AS WRIT_PREM,
	CAST(COALESCE(SUM(COMM_PD), 0) AS DECIMAL(18,2)) AS COMM_PD,
	CAST(COALESCE(SUM(COMM_UNPD), 0) * -1 AS DECIMAL(18,2)) AS COMM_UNPD,
	CAST(COALESCE(SUM(UE_PREM) * -1, 0) AS DECIMAL(18,2)) AS UE_PREM,
	CAST(COALESCE(COALESCE(SUM(LOSS_PD), 0) + COALESCE(SUM(SALV_SUB_L), 0), 0) AS DECIMAL(18,2)) AS LOSS_PD,
	CAST(COALESCE(COALESCE(SUM(ALAE_PD), 0) + COALESCE(SUM(SALV_SUB_E), 0), 0) AS DECIMAL(18,2)) AS ALAE_PD,
	CAST(COALESCE(SUM(ULAE_PD), 0) AS DECIMAL(18,2)) AS ULAE_PD,
	CAST(COALESCE(SUM(SALV_SUB_L) * -1, 0) AS DECIMAL(18,2)) AS SALV_SUB_L,
	CAST(COALESCE(SUM(SALV_SUB_E) * -1, 0) AS DECIMAL(18,2)) AS SALV_SUB_E,
	CAST(COALESCE(SUM(LOSS_RES) * -1, 0) AS DECIMAL(18,2)) AS LOSS_RES,
	CAST(COALESCE(SUM(ALAE_RES) * -1, 0) AS DECIMAL(18,2)) AS ALAE_RES,
	0.00 AS ULAE_RES,
	CAST(COALESCE(SUM(LOSS_IBNR) * -1, 0) AS DECIMAL(18,2)) AS LOSS_IBNR,
	CAST(COALESCE(SUM(ALAE_IBNR) * -1, 0) AS DECIMAL(18,2)) AS ALAE_IBNR,
	CAST(COALESCE(SUM(ULAE_IBNR) * -1, 0) AS DECIMAL(18,2)) AS ULAE_IBNR,
	0.00 AS DISC_RES,
	0.00 AS LOSS_SUPP,
	0.00 AS ALAE_SUPP

FROM #AddAffiliateTable AAT

LEFT JOIN fdb.CoverageLookup CL
ON AAT.LOB = CL.LOB

LEFT JOIN fdb.PP_CommerLookup PPCL
ON AAT.LOB = PPCL.LOB

LEFT JOIN fdb.ASLLookup ASLL
ON AAT.LOB = ASLL.LOB

--WHERE
--	RUN_DATE = @RUNDATE

GROUP BY
	RUN_DATE,
	COMPANY_CODE,
	FROM_CO,
	TO_CO,
	SEGMENT,
	UNDER_SEG,
	AFFILIATE,
	STATE,
	TYPE_DAC,
	ACCYR,
	REINS_CODE,
	CL.COVERAGE,
	AS_LINE,
	PPCL.PP_COMMER

ORDER BY
	COMPANY_CODE,
	STATE,
	ACCYR

