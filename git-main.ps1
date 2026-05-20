$branch = git branch --show-current

if ($branch -eq "main") {
    exit 0
}

git checkout main
git fetch --prune
git pull --ff-only
git branch -D $branch
