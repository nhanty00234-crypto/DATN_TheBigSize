const API_BASE_URL = process.env.REACT_APP_API_URL || 'http://localhost:5000/api';

const apiService = {
  // Match endpoints
  getMatches: async () => {
    const response = await fetch(`${API_BASE_URL}/matches`);
    return response.json();
  },

  getMatchById: async (id) => {
    const response = await fetch(`${API_BASE_URL}/matches/${id}`);
    return response.json();
  },

  // Booking endpoints
  createBooking: async (bookingData) => {
    const response = await fetch(`${API_BASE_URL}/bookings`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(bookingData)
    });
    return response.json();
  },

  getBookings: async () => {
    const response = await fetch(`${API_BASE_URL}/bookings`);
    return response.json();
  }
};

export default apiService;
