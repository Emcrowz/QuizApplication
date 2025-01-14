import { BrowserRouter, Routes, Route } from 'react-router-dom';
import { Quiz } from './pages/Quiz';
import { Leaderboard } from './pages/Leaderboard';
import { NotFound } from './pages/NotFound';

export const App = () => {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Quiz />} />
                <Route path="/leaderboard" element={<Leaderboard />} />
                <Route path="*" element={<NotFound />} />
            </Routes>
        </BrowserRouter>
    );
}