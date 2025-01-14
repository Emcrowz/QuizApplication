import React from "react";
import { QuestionModel } from "../types/QuestionModel";
import { Choises } from "./Choises";

interface QuestionProps {
    question: QuestionModel;
    dispatch: any;
    index: number;
    numberOfQuestions: number;
}

export const Question: React.FC<QuestionProps> = ({ question, dispatch, index, numberOfQuestions }) => {
    return (
        <div className="">
            <h1>{question.title}</h1>
            <Choises question={question} dispatch={dispatch} index={index} numberOfQuestions={numberOfQuestions} />
        </div>
    );
}