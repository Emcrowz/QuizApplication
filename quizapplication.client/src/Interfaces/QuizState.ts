import { QuizStatus } from "../Constants/QuizStatus";
import { Participant } from "../Models/Participant";
import { Question } from "../Models/Question";

export interface QuizState {
  status: QuizStatus;
  participant: Participant;
  questions: Question[];
  answers: string[];
  index: number;
  points: number;
}
