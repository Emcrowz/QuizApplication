import { useEffect, useReducer } from "react";
import { Loading } from "../Components/Common/Loading";
import { ErrorPage } from "./ErrorPage";
import { quizInitialState } from "../Constants/QuizInitialState";
import { ParticipantLogin } from "../Components/Start/ParticipantLogin";
import { QuizStatus } from "../Constants/QuizStatus";
import { QuizActionType } from "../Constants/QuizActionType";
import { QuestionComponent } from "../Components/Quiz/QuestionComponent";
import { QuizContainer } from "../Components/Quiz/QuizContainer";
import { quizStateManager } from "../Managers/QuizStateManager";
import { Score } from "../Components/Score/Score";
import { StartContainer } from "../Components/Start/StartContainer";
import { API_ROUTE } from "../Constants/RoutesAndPaths";

export const Quiz: React.FC = () => {
  const [{ status, participant, questions, index }, dispatch] = useReducer(
    quizStateManager,
    quizInitialState
  );

  const numberOfQuestions = questions.length;

  useEffect(function () {
    fetch(API_ROUTE.QUESTIONS)
      .then((res) => res.json())
      .then((data) =>
        dispatch({ type: QuizActionType.DataReceived, payload: data })
      )
      .catch((error) =>
        dispatch({ type: QuizActionType.DataFail, payload: error.message })
      );
  }, []);

  return (
    <div className="h-screen items-center justify-center">
      {status === QuizStatus.Loading && <Loading />}
      {status === QuizStatus.Failed && <ErrorPage />}
      {status === QuizStatus.Ready && (
        <StartContainer>
          <ParticipantLogin
            numberOfQuestions={numberOfQuestions}
            dispatch={dispatch}
          />
        </StartContainer>
      )}
      {status === QuizStatus.Start && (
        <QuizContainer>
          <QuestionComponent
            question={questions[index]}
            dispatch={dispatch}
            index={index}
            numberOfQuestions={numberOfQuestions}
          />
        </QuizContainer>
      )}
      {status === QuizStatus.Finished && (
        <Score
          name={participant.name}
          email={participant.email}
          participationDate={participant.participationDate}
          finalAnswers={participant.finalAnswers}
        />
      )}
    </div>
  );
};
