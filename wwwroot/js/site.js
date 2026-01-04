function toggleDataBsTheme(force) {
  const root = document.documentElement;
  const current = root.getAttribute('data-bs-theme') || 'light';
    let next;
    console.log(current);

  if (force === 'light' || force === 'dark') {
    next = force;
  } else {
    next = current === 'light' ? 'dark' : 'light';
  }

  root.setAttribute('data-bs-theme', next);
  return next;
};