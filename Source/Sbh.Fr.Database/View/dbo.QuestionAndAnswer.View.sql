SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[QuestionAndAnswer]
AS
     SELECT ROW_NUMBER() OVER(ORDER BY A.ID ASC) AS ID,
            A.ID AS ID_QUESTIONS,
            A.ID_CATEGORY,
            D.CATEGORY_DESC,
            A.ID_USER AS ID_USER_QUESTIONS,
            C.USER_NAME AS QUESTIONS_NAME,
            A.QUESTIONS,
            A.CREATED_TIME AS DATE_QUESTION,
            B.ANSWER,
            B.ID_USER_ADMIN AS ID_USER_ANSWER,
            E.USER_NAME AS ANSWER_NAME,
            ISNULL(B.ID_QUESTIONS, -2) AS ID_QUESTIONS_ANSWER,
            B.CREATED_TIME AS DATE_ANSWER,
            TITLE_QUESTIONS,
            CONVERT( VARCHAR, CASE
                                  WHEN MOST_COMMENT >= 1000
                                  THEN MOST_COMMENT / 1000
                                  ELSE MOST_COMMENT
                              END) SUMCOMMENT,
            ( 
     SELECT START_COUNT
     FROM SBH_TM_MOSTCOMMENT
     WHERE A.MOST_COMMENT BETWEEN BEGIN_MOST_COUNT AND END_MOST_COUNT ) MOST_COMMENT
     FROM SBH_TR_QUESTIONS A
          LEFT JOIN SBH_TR_ANSWER B ON B.ID_QUESTIONS = A.ID
          LEFT JOIN SBH_TM_USER_ADMIN C ON C.ID = A.ID_USER
          LEFT JOIN SBH_TM_USER_ADMIN E ON E.ID = B.ID_USER_ADMIN
          LEFT JOIN SBH_TM_CATEGORY_QUESTIONS D ON D.ID = A.ID_CATEGORY
     WHERE A.ROW_STATUS = 0

GO
