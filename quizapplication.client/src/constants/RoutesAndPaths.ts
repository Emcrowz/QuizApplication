interface API {
  QUESTIONS: string;
  PARTICIPANTS: string;
  PARTICIPANT_POST: string;
  TOPTEN: string;
}

export const API_ROUTE: API = {
  QUESTIONS: "http://localhost:5170/questions/getall",
  PARTICIPANTS: "http://localhost:5170/participants/getall",
  PARTICIPANT_POST: "http://localhost:5170/participants/postsingle",
  TOPTEN: "http://localhost:5170/participants/gettop",
};
