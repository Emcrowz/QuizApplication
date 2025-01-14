import { useEffect, useReducer } from "react";
import { useNavigate } from "react-router-dom";
import { Loading } from "../components/Loading";
import { ErrorPage } from "./ErrorPage";
import { quizInitialState } from "../constants/QuizInitialState";
import { ParticipantLogin } from "../components/ParticipantLogin";
import { QuizStatus } from "../constants/QuizStateStatus";
import { QuizActionType } from "../constants/QuizActionType";
import { Question } from "../components/Question";
import { QuizContainer } from "../components/QuizContainer";
import { quizStateManager } from "../constants/QuizStateManager";
import { Score } from "../components/Score";
import { StartContainer } from "../components/StartContainer";

export const Quiz = () => {
    const navigate = useNavigate();
    const [{ participant, questions, status, index, answers, points }, dispatch] = useReducer(quizStateManager, quizInitialState);

    const numberOfQuestions = questions.length;

    useEffect(function () {
        fetch("https://localhost:7219/questions")
            .then((res) => res.json())
            .then((data) => dispatch({ type: QuizActionType.DataReceived, payload: data }))
            .catch((error) => dispatch({ type: QuizActionType.DataFail, payload: error.message }))
    }, []);

    const handleNavigateToLeaderboard = () => {
        navigate('/leaderboard');
    };

    return (
        <div className="my-4 flex justify-center">
            {status === QuizStatus.Loading && <Loading />}
            {status === QuizStatus.Failed && <ErrorPage />}
            {status === QuizStatus.Ready && (
                <StartContainer>
                    <ParticipantLogin numberOfQuestions={numberOfQuestions} dispatch={dispatch} />
                    <button type="button" onClick={handleNavigateToLeaderboard}>Check the Leaderboard</button>
                </StartContainer>
            )}
            {status === QuizStatus.Start && (
                <QuizContainer>
                    <Question question={questions[index]} dispatch={dispatch} index={index} numberOfQuestions={numberOfQuestions} />
                </QuizContainer>
            )}
            {status === QuizStatus.Finished && (
                <Score name={participant.name} email={participant.email} score={points} participationDate={participant.participationDate} />
            )}
        </div>
    );
};