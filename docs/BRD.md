# DevSquare – Business Requirements Document  

## Overview  
**DevSquare** is a simple forum platform inspired by Hacker News, built for developers to share resources, discuss topics, and upvote content.  
This document describes the **functional requirements** of the system for **Guests, Users, and Admins**.  

---

## Functional Requirements  

### Guest  
- View the **feed page**.  
- Sign up with **username, password, and confirm password**.  
- Cannot **upvote** a resource until registered.  
- Cannot **add a new resource post** until registered.  
- Click on a resource to **view comments**.  
- **Filter** resource posts by tags.  
- **Search** posts by **title** or **URL**.  
- **Sort** posts by:  
  - Latest  
  - Oldest  
  - Top Voted  

---

### User  
- Login with **username and password**.  
- Access all **Guest functionality**.  
- Create new **resource posts** (resource creation form).  
- Upvote posts (including their own).  
- Comment on resource posts.  
- Receive **notifications** when:  
  - Someone comments on their post  
  - Someone replies to their comment  
- Comments sorted by **latest**.  
- Manage own content:  
  - Edit or delete their posts and comments  
  - When deleting a post, the system asks for **password confirmation**  

---

### Admin  

#### Post & Comment Management  
- Search, filter, and sort posts/comments.  
- Delete inappropriate resource posts.  

#### Dashboard & Statistics  
- Admin dashboard with:  
  - Total number of users  
  - Total number of posts  
  - Total number of comments  
  - Recent activity (latest 5 posts)  

#### User Management  
- List all registered users.  
- Search/filter users by **name, email, or role**.  
- Assign or remove roles (**Admin / User**).  
- Deactivate or delete users (**ban feature**).  
- View user activities (their posts & comments).  

---

## Notes  
- Non-functional requirements (e.g., performance, scalability, security, responsiveness) will be added later.  
- Real-time features (like live comments) may be included in future updates.  
