import React, { useState, useEffect } from 'react';
import MatchCard from '../components/MatchCard';

const DashboardPage = () => {
  const [matches, setMatches] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    // Fetch matches from API
    fetchMatches();
  }, []);

  const fetchMatches = async () => {
    try {
      // Call API service
      setLoading(false);
    } catch (error) {
      console.error('Error fetching matches:', error);
    }
  };

  return (
    <div className="dashboard-page">
      <h1>Dashboard</h1>
      <div className="matches-grid">
        {matches.map(match => (
          <MatchCard key={match.id} match={match} />
        ))}
      </div>
    </div>
  );
};

export default DashboardPage;
