import { QuizActionType } from "../constants/QuizActionType";

interface ChoisesAnswerButtonProps {
    dispatch: any;
    index: number;
    numberOfQuestions: number;
    selectedAnswers: string[];
}

export const ChoisesAnswerButton: React.FC<ChoisesAnswerButtonProps> = ({ dispatch, index, numberOfQuestions, selectedAnswers }) => {
    if (index < numberOfQuestions - 1) {
        return <button className="p-4 bg-cyan-500/40 rounded-lg" type="button" onClick={() => dispatch({ type: QuizActionType.QuestionAnswered, payload: selectedAnswers })}>Next Question</button>
    }

    if (index === numberOfQuestions - 1) {
        return <button className="p-4 bg-cyan-500/40 rounded-lg" type="button" onClick={() => dispatch({ type: QuizActionType.QuestionAnsweredFinal, payload: selectedAnswers })}>Finish Quiz</button>
    }
}