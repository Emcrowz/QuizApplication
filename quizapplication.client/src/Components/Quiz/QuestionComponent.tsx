import React from "react";
import { Question } from "../../Models/Question";
import { Choises } from "./Choises";
import { QuizAction } from "../../Interfaces/QuizAction";

interface QuestionProps {
  question: Question;
  dispatch: React.ActionDispatch<[action: QuizAction]>;
  index: number;
  numberOfQuestions: number;
}

export const QuestionComponent: React.FC<QuestionProps> = ({
  question,
  dispatch,
  index,
  numberOfQuestions,
}) => {
  return (
    <div className="content-center w-2/3">
      <div className="border-2 border-blue-300/50 p-12 rounded-xl bg-blue-300/75">
        <h1 className="mb-4 break-words text-6xl select-none">
          {question.title}
        </h1>
        <Choises
          question={question}
          dispatch={dispatch}
          index={index}
          numberOfQuestions={numberOfQuestions}
        />
      </div>
    </div>
  );
};
